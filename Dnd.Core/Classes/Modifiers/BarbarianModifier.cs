namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Saves;

    public class BarbarianModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Barbarian; } }

        public override int HitDie { get { return 12; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Poor; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Good; } }

        public override int GetSkillPointsCreation(DefaultCharacter subject) {
            return (4 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(DefaultCharacter subject) {
            return 4 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(DefaultCharacter subject) {
            base.ModifyOnCreation(subject);
        }

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
