namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Enums;

    public abstract class AbstractSingleHandedWeapon : AbstractWeapon
    {
        public override WeaponType Type { get { return WeaponType.OneHanded; } }

        public override IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.RightHand }; } }
    }
}
