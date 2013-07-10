namespace Dnd.Core.Items
{
    using System.Collections.Generic;

    public interface IItem
    {
        string Name { get; }
        IEnumerable<EqSlot> Slots { get; }
    }
}
