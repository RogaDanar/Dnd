namespace Dnd.Core.Character
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Modifiers;
    using Dnd.Core.Character.Saves;
    using Dnd.Core.Character.Skills;
    using Dnd.Core.Classes;
    using Dnd.Core.Classes.Modifiers;
    using Dnd.Core.Items;
    using Dnd.Core.Races;

    public class DefaultCharacter : IModifiable<DefaultCharacter>, ISize
    {
        private readonly ModifierProvider _modifierProvider;

        public string Name { get; set; }

        // Level
        public int Level { get { return Classes.Sum(x => x.Value.Level); } }
        // MaxLevel is derived from the experience:  maxLvl = 1/2 + 1/2sqrt(1+xp/125) 
        public int MaxLevel { get { return (int)Math.Floor((1f + Math.Sqrt(1f + ((double)Experience / 125f))) / 2f); } }
        public int Experience { get; private set; }
        public int UnusedLevels { get { return MaxLevel - Level; } }
        public bool CanLevel { get { return UnusedLevels > 0; } }

        public int UnusedAttributePoints { get; private set; }
        public int UnusedFeatures { get; private set; }
        public int UnusedSkillPoints { get; private set; }

        // Stats
        public Race Race { get; private set; }
        public Dictionary<ClassType, IClass> Classes { get; private set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public int HpMax { get; set; }
        public int HpCurrent { get; set; }

        // Saves
        public Dictionary<SaveType, int> SaveBonusses { get; private set; }
        public int FortitudeSave { get { return Classes.Sum(x => x.Value.FortitudeSave.Value) + SaveBonusses[SaveType.Fortitude]; } }
        public int ReflexSave { get { return Classes.Sum(x => x.Value.ReflexSave.Value) + SaveBonusses[SaveType.Reflex]; } }
        public int WillSave { get { return Classes.Sum(x => x.Value.WillSave.Value) + SaveBonusses[SaveType.Will]; } }

        // Attacks
        public Dictionary<WeaponType, int> AttackBonusses { get; private set; }

        // TODO: Spells

        // Attributes
        private AttributeList _attributes;
        public IEnumerable<ReadOnlyAttribute> Attributes { get { return _attributes.AsEnumerable(); } }
        public ReadOnlyAttribute Strength { get { return _attributes[AttributeType.Strength]; } }
        public ReadOnlyAttribute Dexterity { get { return _attributes[AttributeType.Dexterity]; } }
        public ReadOnlyAttribute Constitution { get { return _attributes[AttributeType.Constitution]; } }
        public ReadOnlyAttribute Intelligence { get { return _attributes[AttributeType.Intelligence]; } }
        public ReadOnlyAttribute Wisdom { get { return _attributes[AttributeType.Wisdom]; } }
        public ReadOnlyAttribute Charisma { get { return _attributes[AttributeType.Charisma]; } }

        // Features
        private FeatureList _features;
        public IEnumerable<Feature> Features { get { return _features; } }

        // Skills
        private SkillList _skills;
        public IEnumerable<KeyValuePair<SkillType, int>> Skills { get { return _skills.GetAllSkills(); } }

        // Equipment
        public Equipment Equipment { get; private set; }

        public int GetAc(bool flatFooted = false) {
            var dexModifier = flatFooted ? 0 : Dexterity.Modifier;
            var armorAc = Equipment.GetArmorAc();
            return 10 + dexModifier + armorAc;
        }

        public DefaultCharacter(ClassType classType, Race race, ModifierProvider modifierProvider) {
            _modifierProvider = modifierProvider;
            Classes = new Dictionary<ClassType, IClass> { { classType, ClassProvider.GetNewClass(classType, _modifierProvider) } };
            SaveBonusses = new Dictionary<SaveType, int> { { SaveType.Fortitude, 0 }, { SaveType.Reflex, 0 }, { SaveType.Will, 0 } };
            AttackBonusses = new Dictionary<WeaponType, int> { { WeaponType.OneHanded, 0 }, { WeaponType.TwoHanded, 0 }, { WeaponType.Ranged, 0 } };
            Race = race;

            OnCreation(classType);
        }

        public IEnumerable<int> GetAttacks(WeaponType weaponType) {
            var baseAttack = Classes.Sum(x => x.Value.Attack);
            do {
                yield return GetAttackScore(baseAttack, weaponType);
                baseAttack -= 5;
            } while (baseAttack > 0);
        }

        public void AddExperience(int amount) {
            Experience += amount;
        }

        /// <summary>
        /// Adds the number of given levels to the character
        /// </summary>
        public void SetExperienceToLevel(int levels) {
            while (levels > 1) {
                SetExperienceToNextLevel();
                levels--;
            }
        }

        /// <summary>
        /// Sets the character experience to the amount needed for the next level. 
        /// TODO: implement multiclassing
        /// </summary>
        public void SetExperienceToNextLevel() {
            Experience = (MaxLevel + 1) * (MaxLevel) * 500;
        }

        public void LevelUp(ClassType charClass) {
            if (CanLevel) {
                OnLevelGained(charClass);
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

        public void AddSaveBonus(SaveType saveType, int amount) {
            SaveBonusses[saveType] += amount;
        }

        public void AcceptOnCreation(IModifier<DefaultCharacter> modifier) {
            if (Experience == 0) {
                modifier.ModifyOnCreation(this);
            } else {
                throw new InvalidOperationException("Only a new character can be modified with ModifyOnCreation");
            }
        }

        public void AcceptOnLevel(IModifier<DefaultCharacter> modifier) {
            if (Level <= MaxLevel) {
                modifier.ModifyOnLevel(this);
            } else {
                throw new InvalidOperationException("The character must be able to level to be modified by ModifyOnLevel");
            }
        }

        public void AcceptOnMultiClass(IClassModifier modifier) {
            if (Level <= MaxLevel) {
                modifier.ModifyOnMultiClass(this);
            } else {
                throw new InvalidOperationException("The character must be able to level to be modified by ModifyOnMultiClass");
            }
        }

        public bool EquipItem(IItem item) {
            if (CanEquip(item)) {
                Equipment.Equip(item);
                return true;
            }
            return false;
        }

        public IWeapon GetWeapon() {
            return Equipment.GetEquipedWeapon();
        }

        private void OnCreation(ClassType charClass) {
            Equipment = new Equipment();
            _attributes = new AttributeList();
            _features = new FeatureList();
            _skills = new SkillList(_attributes);
            Experience = 0;

            AcceptOnCreation(_modifierProvider.GetBaseModifier());
            AcceptOnCreation(_modifierProvider.GetRaceModifier(Race));
            AcceptOnCreation(Classes[charClass].Modifier);
        }

        private void OnLevelGained(ClassType classType) {
            AcceptOnLevel(_modifierProvider.GetBaseModifier());
            AcceptOnLevel(_modifierProvider.GetRaceModifier(Race));
            if (Classes.ContainsKey(classType)) {
                Classes[classType] = ClassProvider.GetNextLevel(Classes[classType], _modifierProvider);
                AcceptOnLevel(Classes[classType].Modifier);
            } else {
                Classes.Add(classType, ClassProvider.GetNewClass(classType, _modifierProvider));
                AcceptOnMultiClass(Classes[classType].Modifier);
            }
        }

        private bool CanEquip(IItem item) {
            // TODO: fix check
            return true;
        }

        private int GetAttackScore(int baseAttack, WeaponType weaponType) {
            switch (weaponType) {
                case WeaponType.OneHanded:
                case WeaponType.TwoHanded:
                    return baseAttack + _attributes[AttributeType.Strength].Modifier + AttackBonusses[weaponType];
                case WeaponType.Ranged:
                    return baseAttack + _attributes[AttributeType.Dexterity].Modifier + AttackBonusses[weaponType];
                default:
                    throw new ArgumentException("weaponType");
            }
        }
    }
}
