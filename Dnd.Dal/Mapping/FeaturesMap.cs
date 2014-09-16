namespace Dnd.Dal.Mapping
{
    using System.Data.Entity.ModelConfiguration;
    using DbModels;

    public class FeaturesMap : EntityTypeConfiguration<DbCharacterFeature>
    {
        public FeaturesMap() {
            ToTable("CharacterFeatures");
        }
    }
}
