﻿namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Saves;

    public class WizardModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Wizard; } }

        public override int HitDie { get { return 4; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Poor; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (2 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 2 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            //subject.Features.Add("Summon Familiar");
            //subject.Features.Add("Scribe Scroll");
        }

        public override void ModifyOnLevel(ICharacter subject) {
            base.ModifyOnLevel(subject);

            if (subject.Experience.Level % 5 == 0) {
                subject.Features.IncreaseFeatureCount(1);
            }
        }
    }
}
