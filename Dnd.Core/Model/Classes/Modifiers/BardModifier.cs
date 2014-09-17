namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;

    public class BardModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Bard; } }

        public override int HitDie { get { return 6; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (6 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 6 + subject.Intelligence.Modifier;
        }

        protected override void ClassModifyOnCreation(ICharacter subject) {
        }

        protected override void ClassModifyOnLevel(ICharacter subject) {
        }

        protected override void ClassModifyOnMultiClass(ICharacter subject) {
        }
    }
}
