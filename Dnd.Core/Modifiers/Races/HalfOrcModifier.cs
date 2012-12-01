namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class HalfOrcModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Strength, 2);
            subject.DecreaseAttribute(AttributeType.Intelligence, 2);
            subject.DecreaseAttribute(AttributeType.Charisma, 2);

            subject.AddFeature(Feature.DarkVision);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
