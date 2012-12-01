namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public abstract class AbstractRaceModifier : IModifier<Character>
    {
        protected Character _character { get; set; }

        public abstract Size Size { get; }
        public abstract int Speed { get; }

        public virtual void ModifyOnCreation(Character subject) {
            _character = subject;

            _character.Size = Size;
            _character.Speed = Speed;
        }

        public virtual void ModifyOnLevel(Character subject) {
            _character = subject;
        }
    }
}
