namespace Dnd.Core.Model.Character
{
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Character.Saves;
    using Dnd.Core.Model.Character.Skills;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Classes.Modifiers;
    using Dnd.Core.Model.Items;
    using Dnd.Core.Model.Races;
    using System;
    using System.Collections.Generic;

    public class DefaultCharacter : ICharacter
    {
        private readonly IModifierProvider _modifierProvider;

        public int Id { get; set; }

        public string Name { get; set; }

        public Race Race { get; private set; }
        public Dictionary<ClassType, IClass> Classes { get; private set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public Hitpoints Hitpoints { get; private set; }
        public Experience Experience { get; private set; }
        public bool IsNew { get { return Experience.Current == 0; } }

        private CharacterAbilities _abilities;
        public IReadOnlyDictionary<AbilityType, ReadOnlyAbility> AbilityScores { get { return _abilities.AsReadOnlyDictionary(); } }
        public ReadOnlyAbility Strength { get { return _abilities.Strength; } }
        public ReadOnlyAbility Dexterity { get { return _abilities.Dexterity; } }
        public ReadOnlyAbility Constitution { get { return _abilities.Constitution; } }
        public ReadOnlyAbility Intelligence { get { return _abilities.Intelligence; } }
        public ReadOnlyAbility Wisdom { get { return _abilities.Wisdom; } }
        public ReadOnlyAbility Charisma { get { return _abilities.Charisma; } }

        /// <summary>
        /// Ability points still available
        /// </summary>
        public int UnusedAbilityPoints { get { return _abilities.UnusedPoints; } }

        /// <summary>
        /// The ability scores with which the character was originally created. This score
        /// in combination with the added scores (through levelling for instance) results in the current value;
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> StartAbilities { get { return _abilities.StartScores; } }

        /// <summary>
        /// Added scores since the original creation. These scores added to the starting scores result in the
        /// current base values.
        /// </summary>
        public IReadOnlyDictionary<AbilityType, int> AddedAbilityScores { get { return _abilities.AddedScores; } }


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

        private DefaultCharacter() { }

        protected DefaultCharacter(IModifierProvider modifierProvider) {

            _modifierProvider = modifierProvider;
        }

        public DefaultCharacter(Race race, ClassType classType, Dictionary<AbilityType, int> abilityScores, IModifierProvider modifierProvider)
            : this(modifierProvider) {
            Race = race;
            InitializeProperties();
            _abilities = new CharacterAbilities(abilityScores);

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

        public void AddAbilityPoints(int amount) {
            _abilities.AddPoints(amount);
        }

        /// <summary>
        /// Increase the given ability with the given amount.
        /// </summary>
        /// <param name="type">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value has no effect</param>
        public void IncreaseAbility(AbilityType type, int points) {
            if (IsNew) {
                _abilities.AddPoints(points);
            }
            _abilities.Increase(type, points);
        }

        /// <summary>
        /// Increase the given ability with the given amount.
        /// </summary>
        /// <param name="type">Specifies the ability to increase</param>
        /// <param name="points">A positive value. Providing a negative value will throw an exception</param>
        public void DecreaseAbility(AbilityType type, int points) {
            _abilities.Decrease(type, points);
        }


        public void LevelUp(ClassType charClass) {
            if (Experience.CanLevel) {
                OnLevelGained(charClass);
            }
        }

        public void AcceptOnCreation(IModifier<ICharacter> modifier) {
            if (IsNew) {
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
