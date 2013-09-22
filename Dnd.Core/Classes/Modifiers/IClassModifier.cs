namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Modifiers;

    public interface IClassModifier : IModifier<ICharacter>
    {
        ClassType ClassType { get; }
        void ModifyOnMultiClass(ICharacter subject);
    }
}
