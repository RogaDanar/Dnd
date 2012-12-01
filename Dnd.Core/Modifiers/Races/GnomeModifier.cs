namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class GnomeModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Constitution, 2);
            subject.DecreaseAttribute(AttributeType.Strength, 2);

            subject.AddFeature(Feature.LowLightVision);

            subject.IncreaseSkillBonus(SkillType.Listen, 2);
            subject.IncreaseSkillBonus(SkillType.Craft, 2);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
