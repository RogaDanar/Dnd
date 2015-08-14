namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Abilities;
    using Dnd.Core.Model.Character.Features;

    public class HalfOrcModifier : RaceModifierTemplate
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.IncreaseAbility(AbilityType.Strength, 2);
            subject.DecreaseAbility(AbilityType.Intelligence, 2);
            subject.DecreaseAbility(AbilityType.Charisma, 2);

            subject.Features.Add(Feature.DarkVision);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) { }
    }
}
