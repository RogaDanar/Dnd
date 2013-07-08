namespace Dnd.Core.Items.Armor
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public class BreastPlate : IArmor
    {
        public int AcBonus { get { return 5; } }
        public int ArmorCheckPenalty { get { return -4; } }
        public Size Size { get; protected set; }

        public IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.Body }; } }

        public BreastPlate(Size size) {
            Size = size;
        }
    }
}
