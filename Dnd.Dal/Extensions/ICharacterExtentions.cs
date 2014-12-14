namespace Dnd.Dal.Extensions
{
    using Core.Model.Character;
    using DbModels;
    using Dnd.Core.Model.Character.Abilities;
    using System.Collections.ObjectModel;
    using System.Linq;

    public static class ICharacterExtentions
    {
        public static DbCharacter ToDbCharacter(this ICharacter character, DbCharacter dbCharacter) {
            dbCharacter.Experience = character.Experience.Current;
            dbCharacter.Race = (int)character.Race;
            dbCharacter.Name = character.Name;
            dbCharacter.HitpointsCurrent = character.Hitpoints.Current;
            dbCharacter.HitpointsMax = character.Hitpoints.Max;

            dbCharacter.Abilities = character.ToDbAbilities(dbCharacter);

            dbCharacter.Classes = new Collection<DbCharacterClass>(character.Classes.Values.Select(x => x.ToDbClass(dbCharacter)).ToList());
            dbCharacter.Features = new Collection<DbCharacterFeature>(character.Features.Select(x => x.ToDbFeature(dbCharacter)).ToList());
            dbCharacter.Skills = new Collection<DbCharacterSkill>(character.Skills.Select(x => x.ToDbSkill(dbCharacter)).ToList());

            return dbCharacter;
        }

        public static DbCharacterAbilities ToDbAbilities(this ICharacter character, DbCharacter dbCharacter) {
            var dbABilities = dbCharacter.Abilities ?? new DbCharacterAbilities();

            //dbABilities.Character = dbCharacter;

            dbABilities.StartStrength = character.StartAbilities[AbilityType.Strength];
            dbABilities.StartDexterity = character.StartAbilities[AbilityType.Dexterity];
            dbABilities.StartConstitution = character.StartAbilities[AbilityType.Constitution];
            dbABilities.StartIntelligence = character.StartAbilities[AbilityType.Intelligence];
            dbABilities.StartWisdom = character.StartAbilities[AbilityType.Wisdom];
            dbABilities.StartCharisma = character.StartAbilities[AbilityType.Charisma];

            dbABilities.ModStrength = character.AddedAbilityScores[AbilityType.Strength];
            dbABilities.ModDexterity = character.AddedAbilityScores[AbilityType.Dexterity];
            dbABilities.ModConstitution = character.AddedAbilityScores[AbilityType.Constitution];
            dbABilities.ModIntelligence = character.AddedAbilityScores[AbilityType.Intelligence];
            dbABilities.ModWisdom = character.AddedAbilityScores[AbilityType.Wisdom];
            dbABilities.ModCharisma = character.AddedAbilityScores[AbilityType.Charisma];

            return dbABilities;
        }
    }
}
