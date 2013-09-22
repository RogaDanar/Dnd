namespace Dnd.Core.Dice
{
    using System;

    public class D2 : IDie
    {
        public Random Random { get; set; }

        public D2() { }

        public D2(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 3);
        }
    }
}
