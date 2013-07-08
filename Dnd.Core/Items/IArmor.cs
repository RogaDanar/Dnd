namespace Dnd.Core.Items
{
    public interface IArmor : IItem, ISize
    {
        int AcBonus { get; }
        int ArmorCheckPenalty { get; }
    }
}
