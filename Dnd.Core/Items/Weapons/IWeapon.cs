namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;

    public interface IWeapon : IItem
    {
        WeaponType Type { get; }

        Size Size { get; }

        IEnumerable<IDie> DamageDice { get; }

        int CritRange { get; }

        int CritMultiplier { get; }
    }
}
