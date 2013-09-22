namespace Dnd.Core.Items.Weapons
{
    using System.Collections.Generic;
    using System.Linq;
    using Dnd.Core.Character;
    using Dnd.Core.Dice;

    public static class WeaponDiceTable
    {
        private static IEnumerable<IDie>[,] _diceTable = new IEnumerable<IDie>[9, 11]
            {
                // 0 fine
                { Enumerable.Empty<IDie>(), Enumerable.Empty<IDie>(), Enumerable.Empty<IDie>(), DiceBag.GetDice<D1>(1), DiceBag.GetDice<D2>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D2>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1) },
                // 1 diminutive
                { Enumerable.Empty<IDie>(), Enumerable.Empty<IDie>(), DiceBag.GetDice<D1>(1), DiceBag.GetDice<D2>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D10>(1) },
                // 2 tiny
                { Enumerable.Empty<IDie>(), DiceBag.GetDice<D1>(1), DiceBag.GetDice<D2>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D10>(1), DiceBag.GetDice<D6>(2) },
                // 3 small
                { DiceBag.GetDice<D1>(1), DiceBag.GetDice<D2>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D10>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D10>(1), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D8>(2) },
                // 4 medium
                { DiceBag.GetDice<D2>(1), DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D10>(1), DiceBag.GetDice<D12>(1), DiceBag.GetDice<D4>(2), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D8>(2), DiceBag.GetDice<D10>(2) },
                // 5 large
                { DiceBag.GetDice<D3>(1), DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D8>(2), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D8>(3), DiceBag.GetDice<D8>(4) },
                // 6 huge
                { DiceBag.GetDice<D4>(1), DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D8>(3), DiceBag.GetDice<D6>(4), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D6>(4), DiceBag.GetDice<D8>(4), DiceBag.GetDice<D8>(6) },
                // 7 gargantuan
                { DiceBag.GetDice<D6>(1), DiceBag.GetDice<D8>(1), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D6>(4), DiceBag.GetDice<D8>(4), DiceBag.GetDice<D6>(6), DiceBag.GetDice<D6>(4), DiceBag.GetDice<D6>(6), DiceBag.GetDice<D8>(6), DiceBag.GetDice<D8>(8) },
                // 8 colossal
                { DiceBag.GetDice<D8>(1), DiceBag.GetDice<D6>(2), DiceBag.GetDice<D6>(3), DiceBag.GetDice<D6>(4), DiceBag.GetDice<D6>(6), DiceBag.GetDice<D8>(6), DiceBag.GetDice<D6>(8), DiceBag.GetDice<D6>(6), DiceBag.GetDice<D6>(8), DiceBag.GetDice<D8>(8), DiceBag.GetDice<D8>(12) }
            };

        public static IEnumerable<IDie> GetDamageDice(Size size, int damageTier) {
            return _diceTable[(int)size + 4, damageTier - 1];
        }
    }
}
