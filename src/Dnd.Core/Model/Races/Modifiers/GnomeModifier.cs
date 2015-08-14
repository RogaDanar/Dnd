namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Skills;

    public class GnomeModifier : RaceModifierTemplate
    {
        public override Size Size { get { return Size.Small; } }
        public override int Speed { get { return 20; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.IncreaseAbility(AbilityType.Constitution, 2);
            subject.DecreaseAbility(AbilityType.Strength, 2);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Listen, 2);
            subject.Skills.IncreaseBonus(SkillType.Craft, 2);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
