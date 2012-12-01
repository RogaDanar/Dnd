namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class ElfModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Dexterity, 2);
            subject.DecreaseAttribute(AttributeType.Constitution, 2);

            subject.AddFeature(Feature.LowLightVision);

            subject.IncreaseSkillBonus(SkillType.Listen, 2);
            subject.IncreaseSkillBonus(SkillType.Search, 2);
            subject.IncreaseSkillBonus(SkillType.Spot, 2);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
