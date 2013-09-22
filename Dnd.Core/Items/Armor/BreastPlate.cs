namespace Dnd.Core.Items.Armor
{
    using System.Collections.Generic;
    using Dnd.Core.Character;

    public class Breastplate : IArmor
    {
        public string Name { get { return "Breastplate"; } }

        public int AcBonus { get { return 5; } }
        public int ArmorCheckPenalty { get { return -4; } }
        public Size Size { get; protected set; }

        public IEnumerable<EquipmentSlot> Slots { get { return new List<EquipmentSlot> { EquipmentSlot.Body }; } }

        public Breastplate(Size size) {
            Size = size;
        }
    }
}
