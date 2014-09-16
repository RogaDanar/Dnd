namespace Dnd.Core.Model.Dice
{
    using System;

    public class D10 : IDie
    {
        public Random Random { get; set; }

        public D10() { }

        public D10(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 11);
        }
    }
}
