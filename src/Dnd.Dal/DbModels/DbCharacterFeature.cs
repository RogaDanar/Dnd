namespace Dnd.Dal.DbModels
{
    using Core.Model;

    public class DbCharacterFeature : IEntity<int>
    {
        public int Id { get; set; }
        public DbCharacter Character { get; set; }
        public int Feature { get; set; }
    }
}
