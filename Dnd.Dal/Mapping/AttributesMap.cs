namespace Dnd.Dal.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using DbModels;

    public class AttributesMap : EntityTypeConfiguration<DbCharacterAttributes>
    {
        public AttributesMap() {
            ToTable("CharacterAttributes");
            //HasRequired(x => x.Character)
            //    .WithRequiredDependent();
        }
    }
}
