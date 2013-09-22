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

        public int DamageTier { get; protected set; }

        public virtual IEnumerable<IDie> DamageDice { get { return WeaponDiceTable.GetDamageDice(Size, DamageTier); } }

        public abstract IEnumerable<EquipmentSlot> Slots { get; }

        public abstract int CritRange { get; }

        public abstract int CritMultiplier { get; }
    }
}
