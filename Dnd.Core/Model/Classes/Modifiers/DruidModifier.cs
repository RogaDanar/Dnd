namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;

    public class DruidModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Druid; } }

        public override int HitDie { get { return 8; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (4 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 4 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);
        }

        public override void ModifyOnLevel(ICharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
