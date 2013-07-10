﻿namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Saves;

    public class SorcerorModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Sorceror; } }

        public override int HitDie { get { return 4; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Poor; } }

        public override int GetSkillPointsCreation(DefaultCharacter subject) {
            return (2 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(DefaultCharacter subject) {
            return 2 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(DefaultCharacter subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeature(Feature.SimpleWeaponProficiency);
            //subject.AddFeature("Summon Familiar");
        }

        public override void ModifyOnLevel(DefaultCharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}