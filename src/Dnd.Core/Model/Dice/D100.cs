namespace Dnd.Core.Model.Dice
{
    using System;

    public class D100 : IDie
    {
        public Random Random { get; set; }

        public D100() { }

        public D100(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 101);
        }
    }
}
