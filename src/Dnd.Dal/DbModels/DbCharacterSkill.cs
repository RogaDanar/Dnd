namespace Dnd.Dal.DbModels
{
    using Core.Model;

    public class DbCharacterSkill : IEntity<int>
    {
        public int Id { get; set; }
        public DbCharacter Character { get; set; }
        public int Type { get; set; }
        public int Ranks { get; set; }
    }
}
