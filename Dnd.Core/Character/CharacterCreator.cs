namespace Dnd.Core.Character
{
    using System.Collections.Generic;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Modifiers;
    using Dnd.Core.Classes;
    using Dnd.Core.Races;

    public static class CharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static DefaultCharacter CreateCharacter(Race race, ClassType classType, int level, Dictionary<AttributeType, int> abilityScores) {
            var character = new DefaultCharacter(classType, race, abilityScores, new ModifierProvider());
            character.Experience.AddForNextLevels(level);
            while (character.Experience.CanLevel) {
                character.LevelUp(classType);
            }
            return character;
        }
    }
}
