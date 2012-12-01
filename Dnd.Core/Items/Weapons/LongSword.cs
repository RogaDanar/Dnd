namespace Dnd.Core.Items.Weapons
{
    using System;
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;

    public class LongSword : AbstractSingleHandedWeapon
    {
        public override WeaponType Type { get { return WeaponType.OneHanded; } }

        public override IEnumerable<IDie> DamageDice {
            get {
                switch (Size) {
                    case Size.Tiny:
                        return new List<IDie> { Dice.GetDie<D4>() };
                    case Size.Small:
                        return new List<IDie> { Dice.GetDie<D6>() };
                    case Size.Medium:
                        return new List<IDie> { Dice.GetDie<D8>() };
                    case Size.Large:
                        return new List<D6> { Dice.GetDie<D6>(), Dice.GetDie<D6>() };
                    case Size.Fine:
                    case Size.Diminutive:
                    case Size.Huge:
                    case Size.Gargantuan:
                    case Size.Colossal:
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public override int CritRange { get { return 19; } }

        public override int CritMultiplier { get { return 2; } }

        public LongSword(Size size) {
            Size = size;
        }
    }
}
