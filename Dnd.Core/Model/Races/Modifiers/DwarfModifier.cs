namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Features;

    public class DwarfModifier : RaceModifierTemplate
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 20; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Abilities.Increase(AbilityType.Constitution, 2);
            subject.Abilities.Decrease(AbilityType.Charisma, 2);

            subject.Features.Add(Feature.DarkVision);
            subject.Features.Add(Feature.WeaponFamiliarity);
            subject.Features.Add(Feature.StoneCunning);
            subject.Features.Add(Feature.Stability);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
