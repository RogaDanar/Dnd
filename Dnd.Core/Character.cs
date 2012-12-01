namespace Dnd.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Attacks;
    using Dnd.Core.Attributes;
    using Dnd.Core.Enums;
    using Dnd.Core.Items;
    using Dnd.Core.Items.Weapons;
    using Dnd.Core.Modifiers;
    using Dnd.Core.Saves;
    using Dnd.Core.Skills;

    public class Character : IModifiable<Character>
    {
        private IModifier<Character> _baseModifier;
        private IModifier<Character> _raceModifier;
        private IModifier<Character> _classModifier;

        public string Name { get; set; }

        public int Level { get { return (int)Math.Floor((1f + Math.Sqrt(1f + ((double)Experience / 125f))) / 2f); } }
        public int Experience { get; private set; }

        public Race Race { get; private set; }
        public Class Class { get; set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public int HpMax { get; set; }
        public int HpCurrent { get; set; }

        private Equipment _equipment;

        private AttackList _attacks;
        public IEnumerable<KeyValuePair<int, int>> GetAttacks(WeaponType weaponType) { return _attacks.GetAllAttacks(weaponType); }

        public int AC { get { return 10 + Dexterity.Modifier + _equipment.GetArmorAc(); } }
        // Spells

        private AttributeList _attributes;
        public IEnumerable<ReadOnlyAttribute> Attributes { get { return _attributes.AsEnumerable(); } }
        public ReadOnlyAttribute Strength { get { return _attributes[AttributeType.Strength]; } }
        public ReadOnlyAttribute Dexterity { get { return _attributes[AttributeType.Dexterity]; } }
        public ReadOnlyAttribute Constitution { get { return _attributes[AttributeType.Constitution]; } }
        public ReadOnlyAttribute Intelligence { get { return _attributes[AttributeType.Intelligence]; } }
        public ReadOnlyAttribute Wisdom { get { return _attributes[AttributeType.Wisdom]; } }
        public ReadOnlyAttribute Charisma { get { return _attributes[AttributeType.Charisma]; } }

        private SavesList _saves;
        public ReadOnlySave FortitudeSave { get { return _saves.FortitudeSave; } }
        public ReadOnlySave ReflexSave { get { return _saves.ReflexSave; } }
        public ReadOnlySave WillSave { get { return _saves.WillSave; } }

        private FeatureList _features;
        public IEnumerable<Feature> Features { get { return _features; } }

        private SkillList _skills;
        public IEnumerable<KeyValuePair<SkillType, int>> Skills { get { return _skills.GetAllSkills(); } }

        public int UnusedAttributePoints { get; private set; }
        public int UnusedFeatures { get; private set; }
        public int UnusedSkillPoints { get; private set; }

        public Character(Class charClass, Race race, ModifierProvider modifierFactory) {
            Class = charClass;
            Race = race;
            _baseModifier = modifierFactory.GetBaseModifier();
            _raceModifier = modifierFactory.GetModifier(Race);
            _classModifier = modifierFactory.GetModifier(Class);

            OnCreation();
        }

        private void OnCreation() {
            _equipment = new Equipment();
            _attributes = new AttributeList();
            _saves = new SavesList(SaveBonusType.Poor, SaveBonusType.Poor, SaveBonusType.Poor);
            _features = new FeatureList();
            _skills = new SkillList(_attributes);
            _attacks = new AttackList(AttackBonusType.Poor, _attributes);
            Experience = 0;

            AcceptOnCreation(_baseModifier);
            AcceptOnCreation(_raceModifier);
            AcceptOnCreation(_classModifier);
        }

        private void OnLevelGained(int level) {
            AcceptOnLevel(_baseModifier);
            AcceptOnLevel(_raceModifier);
            AcceptOnLevel(_classModifier);
        }

        public void SetExperienceToNextLevel() {
            Experience = (Level + 1) * (Level) * 500;
            OnLevelGained(Level);
        }

        public void AddExperience(int amount) {
            var levelBefore = Level;
            Experience += amount;
            var levelAfter = Level;
            for (int level = levelBefore; level < levelAfter; level++) {
                OnLevelGained(level);
            }
        }

        public void AddFeature(Feature feature) {
            _features.AddFeature(feature);
        }

        public void IncreaseSkillRanks(SkillType skill, int points, string subSkill = null) {
            _skills.Increase(skill, points, subSkill);
        }

        public void IncreaseSkillBonus(SkillType skill, int points, string subSkill = null) {
            _skills.IncreaseBonus(skill, points, subSkill);
        }

        public void IncreaseAttribute(AttributeType attr, int points) {
            _attributes.Increase(attr, points);
        }

        public void IncreaseSaveLevel() {
            _saves.IncreaseLevel();
        }

        public void IncreaseAttackLevel() {
            _attacks.IncreaseLevel();
        }

        public void DecreaseAttribute(AttributeType attr, int points) {
            if (_attributes[attr] >= points) {
                _attributes.Decrease(attr, points);
            }
        }

        public void AddAttributePoints(int amount) {
            UnusedAttributePoints += amount;
        }

        public void AddFeatures(int amount) {
            UnusedFeatures += amount;
        }

        public void AddSkillPoints(int amount) {
            UnusedSkillPoints += amount;
        }

        public void SetSaveBonus(SaveBonusType fortitude, SaveBonusType reflex, SaveBonusType will) {
            _saves.AdjustSaves(fortitude, reflex, will);
        }

        public void SetAttackBonus(AttackBonusType attackBonusType) {
            _attacks.AdjustAttackBonusType(attackBonusType);
        }

        public void AddSaveBonus(SaveType saveType, int amount) {
            _saves.AdjustBonus(saveType, amount);
        }

        public void AcceptOnCreation(IModifier<Character> modifier) {
            if (Experience == 0) {
                modifier.ModifyOnCreation(this);
            } else {
                throw new InvalidOperationException("Only a new character can be modified with ModifyNew");
            }
        }

        public void AcceptOnLevel(IModifier<Character> modifier) {
            if (Level > 1) {
                modifier.ModifyOnLevel(this);
            } else {
                throw new InvalidOperationException("The character has to be above level 1 to be modified by ModifyLevel");
            }
        }

        public bool EquipItem(IItem item) {
            if (CanEquip(item)) {
                _equipment.Equip(item);
                return true;
            }
            return false;
        }

        private bool CanEquip(IItem item) {
            return true;
        }

        public IWeapon GetWeapon() {
            return _equipment.GetEquipedWeapon();
        }
    }
}
