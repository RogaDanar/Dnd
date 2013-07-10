namespace Dnd.Core.Character
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Modifiers;
    using Dnd.Core.Classes;
    using Dnd.Core.Races;

    public static class CharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static DefaultCharacter CreateCharacter(Race race, ClassType classType, int level) {
            var character = new DefaultCharacter(classType, race, new ModifierProvider());
            character.SetExperienceToLevel(level);
            while (character.CanLevel) {
                character.LevelUp(classType);
            }
            return character;
        }


        public static DefaultCharacter SetAbilities(this DefaultCharacter character, Dictionary<AttributeType, int> abilityScores) {
            foreach (var ability in abilityScores) {
                var diff = ability.Value - character.Attributes.Single(x => x.Type == ability.Key).BaseScore;
                if (diff > 0) {
                    character.IncreaseAttribute(ability.Key, diff);
                } else if (diff < 0) {
                    character.DecreaseAttribute(ability.Key, Math.Abs(diff));
                }
            }
            return character;
        }
    }
}
