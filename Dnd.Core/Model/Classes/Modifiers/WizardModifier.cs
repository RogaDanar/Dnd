namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;

    public class WizardModifier : ClassModifierTemplate
    {
        public override ClassType ClassType { get { return ClassType.Wizard; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Poor; } }

        protected override int HitDie { get { return 4; } }

        protected override int GetSkillPointsCreation(ICharacter subject) {
            return (2 + subject.Intelligence.Modifier) * 4;
        }

        protected override int GetSkillPointsLevel(ICharacter subject) {
            return 2 + subject.Intelligence.Modifier;
        }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            //subject.Features.Add("Summon Familiar");
            //subject.Features.Add("Scribe Scroll");
        }

        protected override void ClassModifyOnLevel(ICharacter subject) {
            if (subject.Experience.Level % 5 == 0) {
                subject.Features.IncreaseFeatureCount(1);
            }
        }

        protected override void ClassModifyOnMultiClass(ICharacter subject) {
        }
    }
}
