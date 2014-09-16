namespace Dnd.Dal.Extensions
{
    using System.Linq;
    using Core.Model.Character.Features;
    using DbModels;

    public static class FeatureExtensions
    {
        public static DbCharacterFeature ToDbFeature(this Feature feature, DbCharacter dbCharacter) {
            var dbClass = dbCharacter.Features.SingleOrDefault(x => x.Feature == (int)feature) ?? new DbCharacterFeature();
            dbClass.Character = dbCharacter;
            dbClass.Feature = (int)feature;
            return dbClass;
        }
    }
}
