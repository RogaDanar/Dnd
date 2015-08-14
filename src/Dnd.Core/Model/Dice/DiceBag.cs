using System.Collections.Generic;

namespace Dnd.Core.Model.Dice
{
    using System;

    public static class DiceBag
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public static TDie GetDie<TDie>() where TDie : IDie, new() {
            return createDie<TDie>();
        }

        public static IEnumerable<TDie> GetDice<TDie>(int number) where TDie : IDie, new() {
            while (number > 0) {
                yield return createDie<TDie>();
                number--;
            }
        }

        private static TDie createDie<TDie>() where TDie : IDie, new() {
            var die = (TDie)Activator.CreateInstance<TDie>();
            die.Random = _random;
            return die;
        }
    }
}
