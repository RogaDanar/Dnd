namespace Dnd.Core.Classes
{
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Saves;
    using Dnd.Core.Classes.Modifiers;

    public interface IClass
    {
        ClassType ClassType { get; }
        IClassModifier Modifier { get; }
        int Level { get; }
        SavesList Saves { get; }
        Save FortitudeSave { get; }
        Save ReflexSave { get; }
        Save WillSave { get; }
        Attack Attack { get; }
    }
}
