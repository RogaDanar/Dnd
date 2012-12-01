namespace Dnd.Core.Items.Shields
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public class TowerShield : IShield
    {
        public int AcBonus { get { return 4; } }

        public IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.LeftHand }; } }
    }
}
