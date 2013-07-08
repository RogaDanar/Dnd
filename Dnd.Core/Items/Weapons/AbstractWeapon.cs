namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;

    public abstract class AbstractWeapon : IWeapon
    {
        public abstract WeaponType Type { get; }

        public virtual Size Size { get; protected set; }

        public abstract IEnumerable<IDie> DamageDice { get; }

        public abstract IEnumerable<EqSlot> Slots { get; }

        public abstract int CritRange { get; }

        public abstract int CritMultiplier { get; }
    }
}
