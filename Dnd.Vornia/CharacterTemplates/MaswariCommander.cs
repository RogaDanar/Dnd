namespace Dnd.Vornia.CharacterTemplates
{
    using System.Collections.Generic;
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;

    public class MaswariCommander : DefaultCharacter
    {
        private static readonly Dictionary<AttributeType, int> abilityScores = new Dictionary<AttributeType, int>() { 
                {AttributeType.Strength, 17},
                {AttributeType.Dexterity, 17},
                {AttributeType.Constitution, 18},
                {AttributeType.Intelligence, 14},
                {AttributeType.Wisdom, 12},
                {AttributeType.Charisma, 15}
            };

        public MaswariCommander()
            : base(ClassType.Fighter, Race.Human, abilityScores, new ModifierProvider()) {
            Experience.AddForNextLevels(16);

            while (Experience.CanLevel) {
                LevelUp(ClassType.Fighter);
            }
            // Attributes gained from levels
            Attributes.Increase(AttributeType.Strength, 1);
            Attributes.Increase(AttributeType.Dexterity, 1);
            Attributes.Increase(AttributeType.Dexterity, 1);
            Attributes.Increase(AttributeType.Charisma, 1);
            Name = "Marendras";
        }
    }
}
