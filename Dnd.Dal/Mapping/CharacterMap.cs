namespace Dnd.Dal.Mapping
{
    using DbModels;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class CharacterMap : EntityTypeConfiguration<DbCharacter>
    {
        public CharacterMap() {
            ToTable("Character");

            HasKey(x => x.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Attributes)
                .WithRequiredPrincipal();

            HasMany(x => x.Classes)
                .WithRequired(x => x.Character)
                .Map(x => x.MapKey("CharacterId"));

            HasMany(x => x.Skills)
                .WithRequired(x => x.Character)
                .Map(x => x.MapKey("CharacterId"));

            HasMany(x => x.Features)
                .WithRequired(x => x.Character)
                .Map(x => x.MapKey("CharacterId"));
        }
    }
}
