namespace Dnd.Vornia.CharacterTemplates
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;
    using System.Collections.Generic;

    public class Maswari : DefaultCharacter
    {
        private static readonly Dictionary<AbilityType, int> abilityScores = new Dictionary<AbilityType, int>() { 
                {AbilityType.Strength, 15},
                {AbilityType.Dexterity, 15},
                {AbilityType.Constitution, 14},
                {AbilityType.Intelligence, 11},
                {AbilityType.Wisdom, 12},
                {AbilityType.Charisma, 12}
            };

        public Maswari()
            : base(Race.Human, ClassType.Fighter, abilityScores, new ModifierProvider()) {
            Experience.AddLevels(12);

            while (Experience.CanLevel) {
                LevelUp(ClassType.Fighter);
            }

            // ABilities gained from levels
            Abilities.Increase(AbilityType.Strength, 1);
            Abilities.Increase(AbilityType.Dexterity, 1);
            Abilities.Increase(AbilityType.Dexterity, 1);
        }
    }
}
