namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Saves;
    using Dnd.Core.Model.Character.Skills;

    public class HalflingModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Attributes.Increase(AttributeType.Dexterity, 2);
            subject.Attributes.Decrease(AttributeType.Strength, 2);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Climb, 2);
            subject.Skills.IncreaseBonus(SkillType.Listen, 2);
            subject.Skills.IncreaseBonus(SkillType.Jump, 2);
            subject.Skills.IncreaseBonus(SkillType.MoveSilently, 2);

            subject.Saves.AddBonus(SaveType.Reflex, 1);
            subject.Saves.AddBonus(SaveType.Will, 1);
            subject.Saves.AddBonus(SaveType.Fortitude, 1);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
