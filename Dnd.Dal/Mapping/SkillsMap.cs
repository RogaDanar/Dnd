namespace Dnd.Dal.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using DbModels;

    public class SkillsMap : EntityTypeConfiguration<DbCharacterSkill>
    {
        public SkillsMap() {
            ToTable("CharacterSkills");
        }
    }
}
