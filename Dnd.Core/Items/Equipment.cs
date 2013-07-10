﻿namespace Dnd.Core.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            return Slots
                .Where(x => x.Value != null && typeof(IArmor).IsAssignableFrom(x.Value.GetType()))
                .Select(x => x.Value)
                .Cast<IArmor>()
                .Sum(x => x.AcBonus);
        }
    }
}