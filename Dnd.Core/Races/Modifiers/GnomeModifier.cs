namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Skills;

    public class GnomeModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Attributes.Increase(AttributeType.Constitution, 2);
            subject.Attributes.Decrease(AttributeType.Strength, 2);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Listen, 2);
            subject.Skills.IncreaseBonus(SkillType.Craft, 2);
        }
    }
}
