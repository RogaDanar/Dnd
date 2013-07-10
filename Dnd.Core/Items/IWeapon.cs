namespace Dnd.Core.Items
{
    using System.Collections.Generic;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Dice;

    public interface IWeapon : IItem, ISize
    {
        WeaponType Type { get; }

        IEnumerable<IDie> DamageDice { get; }

        int CritRange { get; }

        int CritMultiplier { get; }
    }
}
