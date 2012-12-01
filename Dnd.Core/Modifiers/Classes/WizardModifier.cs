namespace Dnd.Core.Modifiers.Classes
{
    using Dnd.Core.Enums;

    public class WizardModifier : AbstractClassModifier
    {
        public override int HitDie { get { return 4; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Poor; } }

        public override int SkillPointsCreation { get { return (2 + _character.Intelligence.Modifier) * 4; } }
        public override int SkillPointsLevel { get { return 2 + _character.Intelligence.Modifier; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            //subject.AddFeature("Summon Familiar");
            //subject.AddFeature("Scribe Scroll");
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);

            if (subject.Level % 5 == 0) {
                subject.AddFeatures(1);
            }
        }
    }
}
