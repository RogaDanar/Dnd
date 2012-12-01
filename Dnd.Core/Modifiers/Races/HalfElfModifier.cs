namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class HalfElfModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeature(Feature.LowLightVision);

            subject.IncreaseSkillBonus(SkillType.Listen, 1);
            subject.IncreaseSkillBonus(SkillType.Search, 1);
            subject.IncreaseSkillBonus(SkillType.Spot, 1);
            subject.IncreaseSkillBonus(SkillType.Diplomacy, 2);
            subject.IncreaseSkillBonus(SkillType.GatherInformation, 2);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
