namespace Dnd.Core.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
