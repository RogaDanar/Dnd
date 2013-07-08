namespace Dnd.Core.Dice
{
    using System;

    public class D4 : IDie
    {
        public Random Random { get; set; }

        public D4() { }

        public D4(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 5);
        }
    }
}
