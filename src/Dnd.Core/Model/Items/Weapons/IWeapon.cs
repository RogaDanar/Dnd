namespace Dnd.Core.Model.Items.Weapons
{
    using System.Collections.Generic;
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Dice;

    public interface IWeapon : IItem, ISize
    {
        WeaponType Type { get; }

        WeaponClass Class { get; }

        int DamageTier { get; }

        IEnumerable<IDie> DamageDice { get; }

        int CritRange { get; }

        int CritMultiplier { get; }
    }
}
