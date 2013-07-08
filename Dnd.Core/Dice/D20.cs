namespace Dnd.Core.Dice
{
    using System;

    public class D20 : IDie
    {
        public Random Random { get; set; }

        public D20() { }

        public D20(Random random) {
            Random = random;
        }

        public int Roll() {
            return Random.Next(1, 21);
            //return new D10(Random).Roll() + new D10(Random).Roll();
        }
    }
}
