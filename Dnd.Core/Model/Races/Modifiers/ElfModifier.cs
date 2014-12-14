namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Skills;

    public class ElfModifier : RaceModifierTemplate
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Abilities.Increase(AbilityType.Dexterity, 2);
            subject.Abilities.Decrease(AbilityType.Constitution, 2);

            subject.Features.Add(Feature.LowLightVision);

            subject.Skills.IncreaseBonus(SkillType.Listen, 2);
            subject.Skills.IncreaseBonus(SkillType.Search, 2);
            subject.Skills.IncreaseBonus(SkillType.Spot, 2);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
