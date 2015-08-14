namespace Dnd.Dal.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using DbModels;

    public class ClassesMap : EntityTypeConfiguration<DbCharacterClass>
    {
        public ClassesMap() {
            ToTable("CharacterClasses");
        }
    }
}
