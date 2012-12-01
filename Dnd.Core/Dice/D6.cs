namespace Dnd.Core.Dice
{
    using System;

    public class D6 : IDie
    {
        public Random Random { get; set; }

        public int Roll() {
            return Random.Next(1, 7);
        }

    }
}
