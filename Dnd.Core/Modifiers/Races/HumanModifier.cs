namespace Dnd.Core.Modifiers.Races
{
    using Dnd.Core.Enums;

    public class HumanModifier : AbstractRaceModifier
    {
        public override Size Size { get { return Size.Medium; } }
        public override int Speed { get { return 30; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeatures(1);
            subject.AddSkillPoints(4);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);

            subject.AddSkillPoints(1);
        }
    }
}
