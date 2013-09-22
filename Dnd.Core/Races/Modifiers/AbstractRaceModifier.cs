namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Modifiers;

    public abstract class AbstractRaceModifier : IModifier<ICharacter>
    {
        public abstract Size Size { get; }
        public abstract int Speed { get; }

        public virtual void ModifyOnCreation(ICharacter subject) {
            subject.Size = Size;
            subject.Speed = Speed;
        }

        public virtual void ModifyOnLevel(ICharacter subject) {
        }
    }
}
