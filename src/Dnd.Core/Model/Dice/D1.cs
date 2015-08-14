namespace Dnd.Core.Model.Dice
{
    using System;

    public class D1 : IDie
    {
        public Random Random { get; set; }

        public D1() { }

        public D1(Random random) {
            Random = random;
        }

        public int Roll() {
            return 1;
        }
    }
}
