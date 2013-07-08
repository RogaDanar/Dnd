namespace Dnd.Core.Items.Shields
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public class TowerShield : IArmor
    {
        public int AcBonus { get { return 4; } }
        public int ArmorCheckPenalty { get { return -10; } }
        public Size Size { get; protected set; }

        public IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.LeftHand }; } }

        public TowerShield(Size size) {
            Size = size;
        }
    }
}
