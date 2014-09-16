namespace Dnd.Dal.Extensions
{
    using Core.Model.Character.Attributes;
    using DbModels;

    public static class AttributeListExtensions
    {
        public static DbCharacterAttributes ToDbAttributes(this AttributeList attributes, DbCharacter dbCharacter) {
            var dbAttributes = dbCharacter.Attributes ?? new DbCharacterAttributes();

            //dbAttributes.Character = dbCharacter;

            dbAttributes.StartStrength = attributes.StartAttributes[AttributeType.Strength];
            dbAttributes.StartDexterity = attributes.StartAttributes[AttributeType.Dexterity];
            dbAttributes.StartConstitution = attributes.StartAttributes[AttributeType.Constitution];
            dbAttributes.StartIntelligence = attributes.StartAttributes[AttributeType.Intelligence];
            dbAttributes.StartWisdom = attributes.StartAttributes[AttributeType.Wisdom];
            dbAttributes.StartCharisma = attributes.StartAttributes[AttributeType.Charisma];

            dbAttributes.ModStrength = attributes.ModAttributes[AttributeType.Strength];
            dbAttributes.ModDexterity = attributes.ModAttributes[AttributeType.Dexterity];
            dbAttributes.ModConstitution = attributes.ModAttributes[AttributeType.Constitution];
            dbAttributes.ModIntelligence = attributes.ModAttributes[AttributeType.Intelligence];
            dbAttributes.ModWisdom = attributes.ModAttributes[AttributeType.Wisdom];
            dbAttributes.ModCharisma = attributes.ModAttributes[AttributeType.Charisma];

            return dbAttributes;
        }
    }
}
