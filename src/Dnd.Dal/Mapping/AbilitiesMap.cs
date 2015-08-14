namespace Dnd.Dal.Mapping
{
    using DbModels;
    using System.Data.Entity.ModelConfiguration;

    public class AbilitiesMap : EntityTypeConfiguration<DbCharacterAbilities>
    {
        public AbilitiesMap() {
            ToTable("CharacterAbilities");
            //HasRequired(x => x.Character)
            //    .WithRequiredDependent();
        }
    }
}
