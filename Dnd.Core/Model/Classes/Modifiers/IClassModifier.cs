namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Character.Saves;

    public interface IClassModifier : IModifier<ICharacter>
    {
        ClassType ClassType { get; }
        SaveBonusType FortitudeSaveType { get; }
        SaveBonusType ReflexSaveType { get; }
        SaveBonusType WillSaveType { get; }
        AttackBonusType AttackBonusType { get; }

        void ModifyOnMultiClass(ICharacter subject);
    }
}
