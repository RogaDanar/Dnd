﻿namespace Dnd.Core.Modifiers.Classes
{
    using Dnd.Core.Enums;

    public class BardModifier : AbstractClassModifier
    {
        public override int HitDie { get { return 6; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        public override int SkillPointsCreation { get { return (6 + _character.Intelligence.Modifier) * 4; } }
        public override int SkillPointsLevel { get { return 6 + _character.Intelligence.Modifier; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}