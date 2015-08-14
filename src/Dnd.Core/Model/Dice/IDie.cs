namespace Dnd.Core.Model.Dice
{
    using System;

    public interface IDie
    {
        Random Random { get; set; }
        int Roll();
    }
}
