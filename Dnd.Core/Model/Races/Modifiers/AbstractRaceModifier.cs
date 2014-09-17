namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Modifiers;

    /// <summary>
    /// Template Method for race modifiers
    /// </summary>
    public abstract class AbstractRaceModifier : IModifier<ICharacter>
    {
        public abstract Size Size { get; }
        public abstract int Speed { get; }

        protected abstract void ClassModifyOnCreation(ICharacter subject);
        protected abstract void ClassModifyOnLevel(ICharacter subject);

        public void ModifyOnCreation(ICharacter subject) {
            subject.Size = Size;
            subject.Speed = Speed;
            ClassModifyOnCreation(subject);
        }

        public void ModifyOnLevel(ICharacter subject) {
            ClassModifyOnLevel(subject);
        }
    }
}
