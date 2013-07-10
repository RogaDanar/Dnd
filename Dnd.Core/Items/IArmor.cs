namespace Dnd.Core.Items
{
    using Dnd.Core.Character;

    public interface IArmor : IItem, ISize
    {
        int AcBonus { get; }
        int ArmorCheckPenalty { get; }
    }
}
