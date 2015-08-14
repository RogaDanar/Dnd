namespace Dnd.Core.Model.Items
{
    using System.Collections.Generic;

    public interface IItem
    {
        string Name { get; }

        IEnumerable<EquipmentSlot> Slots { get; }
    }
}
