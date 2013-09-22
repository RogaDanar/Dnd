namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Character.Attacks;

    public abstract class AbstractTwoHandedWeapon : AbstractWeapon
    {
        public override WeaponType Type { get { return WeaponType.TwoHanded; } }

        public override IEnumerable<EquipmentSlot> Slots { get { return new List<EquipmentSlot> { EquipmentSlot.RightHand, EquipmentSlot.LeftHand }; } }
    }
}
