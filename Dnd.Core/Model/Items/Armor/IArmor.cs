namespace Dnd.Core.Model.Items.Armor
{
    using Dnd.Core.Model.Character;

    public interface IArmor : IItem, ISize
    {
        ArmorClass Class { get; }

        int AcBonus { get; }

        int ArmorCheckPenalty { get; }
    }
}
