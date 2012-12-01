namespace Dnd.Core.Dice
{
    using System;

    public interface IDie
    {
        Random Random { get; set; }
        int Roll();
    }
}
