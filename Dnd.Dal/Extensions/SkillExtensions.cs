namespace Dnd.Dal.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Model.Character.Skills;
    using DbModels;

    public static class SkillExtensions
    {
        public static DbCharacterSkill ToDbSkill(this KeyValuePair<SkillType, int> skill, DbCharacter dbCharacter) {
            var dbClass = dbCharacter.Skills.SingleOrDefault(x => x.Type == (int)skill.Key) ?? new DbCharacterSkill();
            dbClass.Character = dbCharacter;
            dbClass.Ranks = skill.Value;
            dbClass.Type = (int)skill.Key;
            return dbClass;
        }
    }
}
