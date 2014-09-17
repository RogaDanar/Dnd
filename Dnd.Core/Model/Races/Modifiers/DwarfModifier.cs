namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Features;

    public class DwarfModifier : RaceModifierTemplate
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 20; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Attributes.Increase(AttributeType.Constitution, 2);
            subject.Attributes.Decrease(AttributeType.Charisma, 2);

            subject.Features.Add(Feature.DarkVision);
            subject.Features.Add(Feature.WeaponFamiliarity);
            subject.Features.Add(Feature.StoneCunning);
            subject.Features.Add(Feature.Stability);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
