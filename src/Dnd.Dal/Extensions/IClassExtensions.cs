namespace Dnd.Dal.Extensions
{
    using System.Linq;
    using Core.Model.Classes;
    using DbModels;

    public static class IClassExtensions
    {
        public static DbCharacterClass ToDbClass(this IClass charClass, DbCharacter dbCharacter) {
            var dbClass = dbCharacter.Classes.SingleOrDefault(x => x.Id == charClass.Id) ?? new DbCharacterClass();
            dbClass.Character = dbCharacter;
            dbClass.Type = (int)charClass.ClassType;
            dbClass.Level = charClass.Level;
            return dbClass;
        }
    }
}
