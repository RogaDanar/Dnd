namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Saves;
    using Dnd.Core.Character.Skills;

    public class HalflingModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        public override void ModifyOnCreation(DefaultCharacter subject) {
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

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
