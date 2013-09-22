namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Features;
    using Dnd.Core.Character.Saves;

    public class FighterModifier : AbstractClassModifier
    {
        public override ClassType ClassType { get { return ClassType.Fighter; } }

        public override int HitDie { get { return 10; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Poor; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Good; } }

        public override int GetSkillPointsCreation(ICharacter subject) {
            return (2 + subject.Intelligence.Modifier) * 4;
        }
        public override int GetSkillPointsLevel(ICharacter subject) {
            return 2 + subject.Intelligence.Modifier;
        }

        public override void ModifyOnCreation(ICharacter subject) {
            base.ModifyOnCreation(subject);

            subject.Features.IncreaseFeatureCount(1);
            subject.Features.Add(Feature.SimpleWeaponProficiency);
            subject.Features.Add(Feature.MartialWeaponProficiency);
            subject.Features.Add(Feature.LightArmorProficiency);
            subject.Features.Add(Feature.MediumArmorProficiency);
            subject.Features.Add(Feature.HeavyArmorProficiency);
            subject.Features.Add(Feature.ShieldProficiency);
        }

        public override void ModifyOnLevel(ICharacter subject) {
            base.ModifyOnLevel(subject);

            if (subject.Experience.Level % 2 == 0) {
                subject.Features.IncreaseFeatureCount(1);
            }
        }
    }
}
