namespace Dnd.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Enums;
    using Dnd.Core.Items;
    using Dnd.Core.Items.Weapons;

    public class Equipment
    {
        public Dictionary<EqSlot, IItem> Slots { get; private set; }

        public Equipment() {
            Slots = new Dictionary<EqSlot, IItem>();
            Enum.GetValues(typeof(EqSlot))
                .Cast<EqSlot>()
                .ToList()
                .ForEach(x => Slots.Add(x, default(IItem)));
        }

        public void Equip(IItem item) {
            foreach (var slot in item.Slots) {
                Slots[slot] = item;
            }
        }

        public IWeapon GetEquipedWeapon() {
            return Slots[EqSlot.RightHand] as IWeapon;
        }

        public int GetArmorAc() {
            return Slots.Where(x => x.Value != null).Sum(x => x.Value.AcBonus);
        }
    }
}
