namespace Dnd.Dal.Extensions
{
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Dal.DbModels;

    public static class AbilityListExtensions
    {
        public static DbCharacterAbilities ToDbAbilities(this AbilityList abilities, DbCharacter dbCharacter) {
            var dbABilities = dbCharacter.Abilities ?? new DbCharacterAbilities();

            //dbABilities.Character = dbCharacter;

            dbABilities.StartStrength = abilities.StartAbilityScores[AbilityType.Strength];
            dbABilities.StartDexterity = abilities.StartAbilityScores[AbilityType.Dexterity];
            dbABilities.StartConstitution = abilities.StartAbilityScores[AbilityType.Constitution];
            dbABilities.StartIntelligence = abilities.StartAbilityScores[AbilityType.Intelligence];
            dbABilities.StartWisdom = abilities.StartAbilityScores[AbilityType.Wisdom];
            dbABilities.StartCharisma = abilities.StartAbilityScores[AbilityType.Charisma];

            dbABilities.ModStrength = abilities.AddedAbilityScores[AbilityType.Strength];
            dbABilities.ModDexterity = abilities.AddedAbilityScores[AbilityType.Dexterity];
            dbABilities.ModConstitution = abilities.AddedAbilityScores[AbilityType.Constitution];
            dbABilities.ModIntelligence = abilities.AddedAbilityScores[AbilityType.Intelligence];
            dbABilities.ModWisdom = abilities.AddedAbilityScores[AbilityType.Wisdom];
            dbABilities.ModCharisma = abilities.AddedAbilityScores[AbilityType.Charisma];

            return dbABilities;
        }
    }
}
