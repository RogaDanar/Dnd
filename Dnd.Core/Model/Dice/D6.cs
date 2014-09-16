namespace Dnd.Core.Model.Dice
{
    using System;

    public class D6 : IDie
    {
        public Random Random { get; set; }

        public D6() { }

        public D6(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 7);
        }
    }
}
