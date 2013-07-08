namespace Dnd.Core.Items
{
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;

    public interface IWeapon : IItem, ISize
    {
        WeaponType Type { get; }

        IEnumerable<IDie> DamageDice { get; }

        int CritRange { get; }

        int CritMultiplier { get; }
    }
}
