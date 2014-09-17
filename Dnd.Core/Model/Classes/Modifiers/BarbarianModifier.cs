namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;

    public class BarbarianModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Barbarian; } }

        public override int HitDie { get { return 12; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Poor; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Good; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (4 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 4 + subject.Intelligence.Modifier;
        }

        protected override void ClassModifyOnCreation(ICharacter subject) {
        }

        protected override void ClassModifyOnLevel(ICharacter subject) {
        }

        protected override void ClassModifyOnMultiClass(ICharacter subject) {
        }
    }
}
