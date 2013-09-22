namespace Dnd.Core.Items.Shields
{
    using System.Collections.Generic;
    using Dnd.Core.Character;

    public class TowerShield : IArmor
    {
        public string Name { get { return "Tower shield"; } }

        public int AcBonus { get { return 4; } }
        public int ArmorCheckPenalty { get { return -10; } }
        public Size Size { get; protected set; }

        public IEnumerable<EquipmentSlot> Slots { get { return new List<EquipmentSlot> { EquipmentSlot.LeftHand }; } }

        public TowerShield(Size size) {
            Size = size;
        }
    }
}
