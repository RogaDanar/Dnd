namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Character.Attacks;

    public abstract class AbstractTwoHandedWeapon : AbstractWeapon
    {
        public override WeaponType Type { get { return WeaponType.TwoHanded; } }

        public override IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.RightHand, EqSlot.LeftHand }; } }
    }
}
