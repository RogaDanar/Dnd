namespace Dnd.Core.Model.Character
{
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;
    using System.Collections.Generic;

    public static class CharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static ICharacter CreateCharacter(Race race, ClassType classType, int level, Dictionary<AbilityType, int> abilityScores) {
            var character = CreateCharacter(race, classType, abilityScores);
            character.Experience.AddLevels(level);
            while (character.Experience.CanLevel) {
                character.LevelUp(classType);
            }
            return character;
        }

        public static ICharacter CreateCharacter(Race race, ClassType classType, Dictionary<AbilityType, int> abilityScores) {
            return new DefaultCharacter(race, classType, abilityScores, new ModifierProvider());
        }
    }
}
