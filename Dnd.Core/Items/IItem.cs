namespace Dnd.Core.Items
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public interface IItem
    {
        IEnumerable<EqSlot> Slots { get; }

        int AcBonus { get; }
    }
}
