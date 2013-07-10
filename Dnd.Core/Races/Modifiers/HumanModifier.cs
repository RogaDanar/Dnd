namespace Dnd.Core.Races.Modifiers
{
    using Dnd.Core.Character;

    public class HumanModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(DefaultCharacter subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeatures(1);
            subject.AddSkillPoints(4);
        }

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);

            subject.AddSkillPoints(1);
        }
    }
}
