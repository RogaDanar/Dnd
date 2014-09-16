namespace Dnd.Core.Model.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Items.Armor;
    using Dnd.Core.Model.Items.Weapons;

    public class Equipment
    {
        private readonly ICharacter _character;

        public Dictionary<EquipmentSlot, IItem> Slots { get; private set; }

        protected Equipment() { }

        public Equipment(ICharacter character) {
            _character = character;
            Slots = new Dictionary<EquipmentSlot, IItem>();
            Enum.GetValues(typeof(EquipmentSlot))
                .Cast<EquipmentSlot>()
                .ToList()
                .ForEach(x => Slots.Add(x, default(IItem)));
        }

        public bool Equip(IItem item) {
            var canEquip = CanEquip(item);
            if (canEquip) {
                foreach (var slot in item.Slots) {
                    Slots[slot] = item;
                }
            }
            return canEquip;
        }

        private bool CanEquip(IItem item) {
            var weapon = item as IWeapon;
            if (weapon != null) {
                switch (weapon.Class) {
                    case WeaponClass.Simple:
                        return _character.Features.Any(x => x == Feature.SimpleWeaponProficiency);
                    case WeaponClass.Martial:
                        return _character.Features.Any(x => x == Feature.MartialWeaponProficiency);
                    case WeaponClass.Exotic:
                        return _character.Features.Any(x => x == Feature.ExoticWeaponProficiency);
                    default:
                        break;
                }
            }
            var armor = item as IArmor;
            if (armor != null) {
                switch (armor.Class) {
                    case ArmorClass.Light:
                        return _character.Features.Any(x => x == Feature.LightArmorProficiency);
                    case ArmorClass.Medium:
                        return _character.Features.Any(x => x == Feature.MediumArmorProficiency);
                    case ArmorClass.Heavy:
                        return _character.Features.Any(x => x == Feature.HeavyArmorProficiency);
                    case ArmorClass.Shield:
                        return _character.Features.Any(x => x == Feature.ShieldProficiency);
                    default:
                        break;
                }
            }
            return false;
        }

        public IWeapon GetEquipedWeapon() {
            return Slots[EquipmentSlot.RightHand] as IWeapon;
        }

        public int GetArmorAc() {
            return Slots
                .Select(x => x.Value)
                .OfType<IArmor>()
                .Sum(x => x.AcBonus);
        }
    }
}
