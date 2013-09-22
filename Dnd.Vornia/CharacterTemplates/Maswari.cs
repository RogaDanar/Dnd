using System.Collections.Generic;
using Dnd.Core.Character.Attributes;

namespace Dnd.Vornia.CharacterTemplates
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Modifiers;
    using Dnd.Core.Classes;
    using Dnd.Core.Races;

    public class Maswari : DefaultCharacter
    {
        private static readonly Dictionary<AttributeType, int> abilityScores = new Dictionary<AttributeType, int>() { 
                {AttributeType.Strength, 15},
                {AttributeType.Dexterity, 15},
                {AttributeType.Constitution, 14},
                {AttributeType.Intelligence, 11},
                {AttributeType.Wisdom, 12},
                {AttributeType.Charisma, 12}
            };

        public Maswari()
            : base(ClassType.Fighter, Race.Human, abilityScores, new ModifierProvider()) {
            Experience.AddForNextLevels(12);
            while (Experience.CanLevel) {
                LevelUp(ClassType.Fighter);
            }
            // Attributes gained from levels
            Attributes.Increase(AttributeType.Strength, 1);
            Attributes.Increase(AttributeType.Dexterity, 1);
            Attributes.Increase(AttributeType.Dexterity, 1);
        }
    }
}
