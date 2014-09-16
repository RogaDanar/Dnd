namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Skills;

    public class HalfElfModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Listen, 1);
            subject.Skills.IncreaseBonus(SkillType.Search, 1);
            subject.Skills.IncreaseBonus(SkillType.Spot, 1);
            subject.Skills.IncreaseBonus(SkillType.Diplomacy, 2);
            subject.Skills.IncreaseBonus(SkillType.GatherInformation, 2);
        }
    }
}
