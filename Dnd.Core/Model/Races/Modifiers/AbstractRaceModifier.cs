namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Modifiers;

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
