namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Dice;

    public abstract class AbstractWeapon : IWeapon
    {
        public abstract string Name { get; }

        public abstract WeaponType Type { get; }

        public virtual Size Size { get; protected set; }

        public abstract IEnumerable<IDie> DamageDice { get; }

        public abstract IEnumerable<EqSlot> Slots { get; }

        public abstract int CritRange { get; }

        public abstract int CritMultiplier { get; }

    }
}
