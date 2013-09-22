namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Skills;

    public class ElfModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Attributes.Increase(AttributeType.Dexterity, 2);
            subject.Attributes.Decrease(AttributeType.Constitution, 2);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Listen, 2);
            subject.Skills.IncreaseBonus(SkillType.Search, 2);
            subject.Skills.IncreaseBonus(SkillType.Spot, 2);
        }
    }
}
