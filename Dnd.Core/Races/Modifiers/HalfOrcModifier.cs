namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Features;

    public class HalfOrcModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(DefaultCharacter subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Strength, 2);
            subject.DecreaseAttribute(AttributeType.Intelligence, 2);
            subject.DecreaseAttribute(AttributeType.Charisma, 2);

            subject.AddFeature(Feature.DarkVision);
        }

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
