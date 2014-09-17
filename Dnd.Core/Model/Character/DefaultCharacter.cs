namespace Dnd.Core.Model.Character
{
    using System;
    using System.Collections.Generic;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Character.Saves;
    using Dnd.Core.Model.Character.Skills;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Classes.Modifiers;
    using Dnd.Core.Model.Items;
    using Dnd.Core.Model.Races;

    public class DefaultCharacter : ICharacter
    {
        private readonly ModifierProvider _modifierProvider;

        public int Id { get; set; }

        public string Name { get; set; }

        public Race Race { get; private set; }
        public Dictionary<ClassType, IClass> Classes { get; private set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public Hitpoints Hitpoints { get; private set; }
        public Experience Experience { get; private set; }

        public AttributeList Attributes { get; private set; }
        public ReadOnlyAttribute Strength { get { return Attributes.Strength; } }
        public ReadOnlyAttribute Dexterity { get { return Attributes.Dexterity; } }
        public ReadOnlyAttribute Constitution { get { return Attributes.Constitution; } }
        public ReadOnlyAttribute Intelligence { get { return Attributes.Intelligence; } }
        public ReadOnlyAttribute Wisdom { get { return Attributes.Wisdom; } }
        public ReadOnlyAttribute Charisma { get { return Attributes.Charisma; } }

        public SavesList Saves { get; private set; }
        public AttackList Attacks { get; private set; }
        public FeatureList Features { get; private set; }
        public SkillList Skills { get; private set; }

        public Equipment Equipment { get; private set; }
        public int AC(bool surprised = false) {
            const int baseAc = 10;
            const int flatFootedAc = 0;
            var dexModifier = surprised ? flatFootedAc : Dexterity.Modifier;
            var armorAc = Equipment.GetArmorAc();
            return baseAc + dexModifier + armorAc;
        }

        // TODO: Spells

        protected DefaultCharacter() {

        }

        public DefaultCharacter(ClassType classType, Race race, Dictionary<AttributeType, int> abilityScores, ModifierProvider modifierProvider) {
            _modifierProvider = modifierProvider;
            Race = race;
            InitializeProperties();
            Attributes = new AttributeList(abilityScores);
            var characterClass = ClassProvider.GetNewClass(classType, _modifierProvider);
            Classes.Add(classType, characterClass);
            // Once all the properties are set, OnCreation can be called, which will process all modifiers for this character/class/race
            OnCreation(classType);
        }

        private void InitializeProperties() {
            Classes = new Dictionary<ClassType, IClass>();
            Attacks = new AttackList(this);
            Saves = new SavesList(this);
            Hitpoints = new Hitpoints();
            Equipment = new Equipment(this);
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

        private void OnCreation(ClassType charClass) {
            AcceptOnCreation(_modifierProvider.GetBaseModifier());
            AcceptOnCreation(_modifierProvider.GetRaceModifier(Race));
            AcceptOnCreation(Classes[charClass].Modifier);
            // Prevent further editing to the Attributes and Features outside of levelling
            Attributes.DoneCreating();
            Features.DoneCreating();
        }

        private void OnLevelGained(ClassType classType) {
            // Class modifier must be run first, because it increases the class level on which the characterlevel is dependant
            if (Classes.ContainsKey(classType)) {
                Classes[classType] = ClassProvider.GetNextLevel(Classes[classType], _modifierProvider);
                AcceptOnLevel(Classes[classType].Modifier);
            } else {
                Classes.Add(classType, ClassProvider.GetNewClass(classType, _modifierProvider));
                AcceptOnMultiClass(Classes[classType].Modifier);
            }
            // Now the new level is set to the character, the other modifiers can be called with the correct level
            AcceptOnLevel(_modifierProvider.GetBaseModifier());
            AcceptOnLevel(_modifierProvider.GetRaceModifier(Race));
        }
    }
}
