namespace Dnd.Core.Model.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Model.Character.Attacks;

    public abstract class AbstractSingleHandedWeapon : AbstractWeapon
    {
        public override WeaponType Type { get { return WeaponType.OneHanded; } }

        public override IEnumerable<EquipmentSlot> Slots { get { return new List<EquipmentSlot> { EquipmentSlot.RightHand }; } }
    }
}
