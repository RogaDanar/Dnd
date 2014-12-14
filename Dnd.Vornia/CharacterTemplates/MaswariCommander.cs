namespace Dnd.Vornia.CharacterTemplates
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;
    using System.Collections.Generic;

    public class MaswariCommander : DefaultCharacter
    {
        private static readonly Dictionary<AbilityType, int> abilityScores = new Dictionary<AbilityType, int>() { 
                {AbilityType.Strength, 17},
                {AbilityType.Dexterity, 17},
                {AbilityType.Constitution, 18},
                {AbilityType.Intelligence, 14},
                {AbilityType.Wisdom, 12},
                {AbilityType.Charisma, 15}
            };

        public MaswariCommander()
            : base(Race.Human, ClassType.Fighter, abilityScores, new ModifierProvider()) {
            Experience.AddLevels(16);

            while (Experience.CanLevel) {
                LevelUp(ClassType.Fighter);
            }
            // Attributes gained from levels
            Abilities.Increase(AbilityType.Strength, 1);
            Abilities.Increase(AbilityType.Dexterity, 1);
            Abilities.Increase(AbilityType.Dexterity, 1);
            Abilities.Increase(AbilityType.Charisma, 1);
            Name = "Marendras";
        }
    }
}
