namespace Dnd.Dal.DbModels
{
    using Core.Model;

    public class DbCharacterClass : IEntity<int>
    {
        public int Id { get; set; }
        public DbCharacter Character { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
    }
}
