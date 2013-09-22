namespace Dnd.Core.Character
{
    using System;
    using System.Collections.Generic;
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

    public class DefaultCharacter : ICharacter
    {
        private readonly ModifierProvider _modifierProvider;

        public string Name { get; set; }

        // Stats
        public Race Race { get; private set; }
        public Dictionary<ClassType, IClass> Classes { get; private set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public Hitpoints Hitpoints { get; set; }
        public Experience Experience { get; set; }

        // Attributes
        public AttributeList Attributes { get; private set; }
        public ReadOnlyAttribute Strength { get { return Attributes.Strength; } }
        public ReadOnlyAttribute Dexterity { get { return Attributes.Dexterity; } }
        public ReadOnlyAttribute Constitution { get { return Attributes.Constitution; } }
        public ReadOnlyAttribute Intelligence { get { return Attributes.Intelligence; } }
        public ReadOnlyAttribute Wisdom { get { return Attributes.Wisdom; } }
        public ReadOnlyAttribute Charisma { get { return Attributes.Charisma; } }

        // Saves
        public SavesList Saves { get; private set; }

        // Attacks
        public AttackList Attacks { get; private set; }

        // Features
        public FeatureList Features { get; private set; }

        // Skills
        public SkillList Skills { get; private set; }

        // Equipment
        public Equipment Equipment { get; private set; }

        // TODO: Spells

        public int GetAc(bool flatFooted = false) {
            var dexModifier = flatFooted ? 0 : Dexterity.Modifier;
            var armorAc = Equipment.GetArmorAc();
            return 10 + dexModifier + armorAc;
        }

        public DefaultCharacter(ClassType classType, Race race, Dictionary<AttributeType, int> abilityScores, ModifierProvider modifierProvider) {
            _modifierProvider = modifierProvider;
            Race = race;
            Classes = new Dictionary<ClassType, IClass> { { classType, ClassProvider.GetNewClass(classType, _modifierProvider) } };
            Attributes = new AttributeList(abilityScores);
            InitializeProperties();
            OnCreation(classType);
        }

        private void InitializeProperties() {
            Attacks = new AttackList(this);
            Saves = new SavesList(this);
            Hitpoints = new Hitpoints();
            Equipment = new Equipment();
            Features = new FeatureList();
            Skills = new SkillList(this);
            Experience = new Experience(this);
        }

        public void LevelUp(ClassType charClass) {
            if (Experience.CanLevel) {
                OnLevelGained(charClass);
            }
        }

        public void AcceptOnCreation(IModifier<ICharacter> modifier) {
            if (Experience.Current == 0) {
                modifier.ModifyOnCreation(this);
            } else {
                throw new InvalidOperationException("Only a new character can be modified with ModifyOnCreation");
            }
        }

        public void AcceptOnLevel(IModifier<ICharacter> modifier) {
            if (Experience.Level <= Experience.MaxLevel) {
                modifier.ModifyOnLevel(this);
            } else {
                throw new InvalidOperationException("The character must be able to level to be modified by ModifyOnLevel");
            }
        }

        public void AcceptOnMultiClass(IClassModifier modifier) {
            if (Experience.Level <= Experience.MaxLevel) {
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
            AcceptOnCreation(_modifierProvider.GetBaseModifier());
            AcceptOnCreation(_modifierProvider.GetRaceModifier(Race));
            AcceptOnCreation(Classes[charClass].Modifier);
            Attributes.DoneCreating();
            Features.DoneCreating();
        }

        private void OnLevelGained(ClassType classType) {
            // Class modifier must be run first, because it changes the Level
            if (Classes.ContainsKey(classType)) {
                Classes[classType] = ClassProvider.GetNextLevel(Classes[classType], _modifierProvider);
                AcceptOnLevel(Classes[classType].Modifier);
            } else {
                Classes.Add(classType, ClassProvider.GetNewClass(classType, _modifierProvider));
                AcceptOnMultiClass(Classes[classType].Modifier);
            }
            AcceptOnLevel(_modifierProvider.GetBaseModifier());
            AcceptOnLevel(_modifierProvider.GetRaceModifier(Race));
        }

        private bool CanEquip(IItem item) {
            // TODO: fix check
            return true;
        }
    }
}
