using Dnd.Vornia.CharacterTemplates;

namespace Dnd.Vornia.Character
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;

    public static class VorniaCharacterCreator
    {
        /// <summary>
        /// Creates a new character and levels it up to the given level
        /// </summary>
        public static DefaultCharacter CreateMaswari() {
            return new Maswari();
        }

        public static DefaultCharacter CreateMaswariCommander() {
            return new MaswariCommander();
        }

        public static DefaultCharacter SetAbilities(this DefaultCharacter character, Dictionary<AttributeType, int> abilityScores) {
            foreach (var ability in abilityScores) {
                var diff = ability.Value - character.Attributes.Single(x => x.Type == ability.Key).BaseScore;
                if (diff > 0) {
                    character.Attributes.Increase(ability.Key, diff);
                } else if (diff < 0) {
                    character.Attributes.Decrease(ability.Key, Math.Abs(diff));
                }
            }
            return character;
        }
    }
}
