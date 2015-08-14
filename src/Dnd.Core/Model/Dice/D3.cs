namespace Dnd.Core.Model.Dice
{
    using System;

    public class D3 : IDie
    {
        public Random Random { get; set; }

        public D3() { }

        public D3(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 4);
        }
    }
}
