namespace Dnd.Dal.Extensions
{
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Dal.DbModels;

    public static class AttributeListExtensions
    {
        public static DbCharacterAttributes ToDbAttributes(this AttributeList attributes, DbCharacter dbCharacter) {
            var dbAttributes = dbCharacter.Attributes ?? new DbCharacterAttributes();

            //dbAttributes.Character = dbCharacter;

            dbAttributes.StartStrength = attributes.StartAttributeScores[AttributeType.Strength];
            dbAttributes.StartDexterity = attributes.StartAttributeScores[AttributeType.Dexterity];
            dbAttributes.StartConstitution = attributes.StartAttributeScores[AttributeType.Constitution];
            dbAttributes.StartIntelligence = attributes.StartAttributeScores[AttributeType.Intelligence];
            dbAttributes.StartWisdom = attributes.StartAttributeScores[AttributeType.Wisdom];
            dbAttributes.StartCharisma = attributes.StartAttributeScores[AttributeType.Charisma];

            dbAttributes.ModStrength = attributes.AddedAttributeScores[AttributeType.Strength];
            dbAttributes.ModDexterity = attributes.AddedAttributeScores[AttributeType.Dexterity];
            dbAttributes.ModConstitution = attributes.AddedAttributeScores[AttributeType.Constitution];
            dbAttributes.ModIntelligence = attributes.AddedAttributeScores[AttributeType.Intelligence];
            dbAttributes.ModWisdom = attributes.AddedAttributeScores[AttributeType.Wisdom];
            dbAttributes.ModCharisma = attributes.AddedAttributeScores[AttributeType.Charisma];

            return dbAttributes;
        }
    }
}
