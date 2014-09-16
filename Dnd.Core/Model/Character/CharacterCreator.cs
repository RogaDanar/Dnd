namespace Dnd.Core.Model.Character
{
    using System.Collections.Generic;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;

    public static class CharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static ICharacter CreateCharacter(Race race, ClassType classType, int level, Dictionary<AttributeType, int> attributeScores) {
            var character = new DefaultCharacter(classType, race, attributeScores, new ModifierProvider());
            character.Experience.AddForNextLevels(level);
            while (character.Experience.CanLevel) {
                character.LevelUp(classType);
            }
            return character;
        }
    }
}
