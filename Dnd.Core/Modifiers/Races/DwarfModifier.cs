namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class DwarfModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 20; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Constitution, 2);
            subject.DecreaseAttribute(AttributeType.Charisma, 2);

            subject.AddFeature(Feature.DarkVision);
            subject.AddFeature(Feature.WeaponFamiliarity);
            subject.AddFeature(Feature.StoneCunning);
            subject.AddFeature(Feature.Stability);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
