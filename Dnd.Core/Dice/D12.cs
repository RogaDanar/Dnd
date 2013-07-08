namespace Dnd.Core.Dice
{
    using System;

    public class D12 : IDie
    {
        public Random Random { get; set; }

        public D12() { }

        public D12(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 13);
        }
    }
}
