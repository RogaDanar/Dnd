namespace Dnd.Core.Model.Classes
{
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;
    using Dnd.Core.Model.Classes.Modifiers;

    public interface IClass : IEntity<int>
    {
        ClassType ClassType { get; }
        IClassModifier Modifier { get; }
        int Level { get; }
        ClassSaves Saves { get; }
        Save FortitudeSave { get; }
        Save ReflexSave { get; }
        Save WillSave { get; }
        Attack Attack { get; }
    }
}
