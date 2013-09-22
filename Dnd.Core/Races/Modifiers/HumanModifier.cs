namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;

    public class HumanModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Features.IncreaseFeatureCount(1);
            subject.Skills.AddRanks(4);
        }

        public override void ModifyOnLevel(ICharacter subject) {
            base.ModifyOnLevel(subject);

            subject.Skills.AddRanks(1);
        }
    }
}
