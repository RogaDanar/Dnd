namespace Dnd.Dal.Extensions
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Core.Model.Character;
    using DbModels;

    public static class ICharacterExtentions
    {
        public static DbCharacter ToDbCharacter(this ICharacter character, DbCharacter dbCharacter) {
            dbCharacter.Experience = character.Experience.Current;
            dbCharacter.Race = (int)character.Race;
            dbCharacter.Name = character.Name;
            dbCharacter.HitpointsCurrent = character.Hitpoints.Current;
            dbCharacter.HitpointsMax = character.Hitpoints.Max;

            dbCharacter.Abilities = character.Abilities.ToDbAbilities(dbCharacter);

            dbCharacter.Classes = new Collection<DbCharacterClass>(character.Classes.Values.Select(x => x.ToDbClass(dbCharacter)).ToList());
            dbCharacter.Features = new Collection<DbCharacterFeature>(character.Features.Select(x => x.ToDbFeature(dbCharacter)).ToList());
            dbCharacter.Skills = new Collection<DbCharacterSkill>(character.Skills.Select(x => x.ToDbSkill(dbCharacter)).ToList());

            return dbCharacter;
        }
    }
}
