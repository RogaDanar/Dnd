namespace Dnd.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Enums;
    using Dnd.Core.Modifiers;

    public static class CharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static Character CreateCharacter(Race race, Class charClass, int level) {
            var character = new Character(charClass, race, new ModifierProvider());
            character.LevelUp(level);
            return character;
        }


        public static Character SetAbilities(this Character character, Dictionary<AttributeType, int> abilityScores) {
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
