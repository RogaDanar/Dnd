namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Modifiers;

    public interface IClassModifier : IModifier<DefaultCharacter>
    {
        ClassType ClassType { get; }
        void ModifyOnMultiClass(DefaultCharacter subject);
    }
}
