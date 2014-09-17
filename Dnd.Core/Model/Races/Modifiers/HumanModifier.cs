namespace Dnd.Core.Model.Races.Modifiers
{
    using Dnd.Core.Model.Character;

    public class HumanModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Features.IncreaseFeatureCount(1);
            subject.Skills.AddRanks(4);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) {
            subject.Skills.AddRanks(1);
        }
    }
}
