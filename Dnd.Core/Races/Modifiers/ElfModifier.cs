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

        public override void ModifyOnCreation(DefaultCharacter subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Dexterity, 2);
            subject.DecreaseAttribute(AttributeType.Constitution, 2);

            subject.AddFeature(Feature.LowLightVision);

            subject.IncreaseSkillBonus(SkillType.Listen, 2);
            subject.IncreaseSkillBonus(SkillType.Search, 2);
            subject.IncreaseSkillBonus(SkillType.Spot, 2);
        }

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
