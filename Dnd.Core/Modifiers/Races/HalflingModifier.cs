namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class HalflingModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.IncreaseAttribute(AttributeType.Dexterity, 2);
            subject.DecreaseAttribute(AttributeType.Strength, 2);

            subject.AddFeature(Feature.LowLightVision);

            subject.IncreaseSkillBonus(SkillType.Climb, 2);
            subject.IncreaseSkillBonus(SkillType.Listen, 2);
            subject.IncreaseSkillBonus(SkillType.Jump, 2);
            subject.IncreaseSkillBonus(SkillType.MoveSilently, 2);

            subject.AddSaveBonus(SaveType.Reflex, 1);
            subject.AddSaveBonus(SaveType.Will, 1);
            subject.AddSaveBonus(SaveType.Fortitude, 1);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
