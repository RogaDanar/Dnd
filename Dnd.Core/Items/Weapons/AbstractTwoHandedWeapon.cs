namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;

    public abstract class AbstractTwoHandedWeapon : IWeapon
    {
        public abstract WeaponType Type { get; }

        public Size Size { get; protected set; }

        public abstract IEnumerable<IDie> DamageDice { get; }

        public IEnumerable<EqSlot> Slots { get { return new List<EqSlot> { EqSlot.RightHand, EqSlot.LeftHand }; } }

        public abstract int CritRange { get; }

        public abstract int CritMultiplier { get; }

        public int AcBonus { get { return 0; } }
    }
}
