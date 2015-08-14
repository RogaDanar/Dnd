namespace Dnd.Core.Model.Items.Armor
{
    using System.Collections.Generic;
    using Dnd.Core.Model.Character;

    public class Breastplate : IArmor
    {
        public string Name { get { return "Breastplate"; } }

        public ArmorClass Class { get { return ArmorClass.Medium; } }

        public int AcBonus { get { return 5; } }
        public int ArmorCheckPenalty { get { return -4; } }
        public Size Size { get; protected set; }

        public IEnumerable<EquipmentSlot> Slots { get { return new List<EquipmentSlot> { EquipmentSlot.Body }; } }

        public Breastplate(Size size) {
            Size = size;
        }
    }
}
