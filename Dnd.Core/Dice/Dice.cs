namespace Dnd.Core.Dice
{
    using System;

    public static class Dice
    {
        private static Random _random = new Random(DateTime.Now.Millisecond);

        public static TDie GetDie<TDie>() where TDie : IDie, new() {
            var die = (TDie)Activator.CreateInstance<TDie>();
            die.Random = _random;
            return die;
        }
    }
}
