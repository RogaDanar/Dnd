﻿namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Saves;

    public class RangerModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Ranger; } }

        public override int HitDie { get { return 8; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Poor; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Good; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (6 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 6 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Features.Add(Feature.SimpleWeaponProficiency);
            subject.Features.Add(Feature.MartialWeaponProficiency);
            subject.Features.Add(Feature.LightArmorProficiency);
            subject.Features.Add(Feature.ShieldProficiency);
            subject.Features.Add(Feature.Track);
            //subject.Features.Add(Feature.WildEmpathy);
        }

        public override void ModifyOnLevel(ICharacter subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
