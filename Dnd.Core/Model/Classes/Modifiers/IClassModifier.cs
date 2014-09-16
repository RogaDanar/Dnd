namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Modifiers;

    public interface IClassModifier : IModifier<ICharacter>
    {
        ClassType ClassType { get; }
        void ModifyOnMultiClass(ICharacter subject);
    }
}
