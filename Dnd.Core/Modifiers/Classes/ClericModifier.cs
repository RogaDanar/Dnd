namespace Dnd.Core.Modifiers.Classes
{
    using Dnd.Core.Enums;

    public class ClericModifier : AbstractClassModifier
    {
        public override int HitDie { get { return 8; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        public override int SkillPointsCreation { get { return (2 + _character.Intelligence.Modifier) * 4; } }
        public override int SkillPointsLevel { get { return 2 + _character.Intelligence.Modifier; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeature(Feature.SimpleWeaponProficiency);
            subject.AddFeature(Feature.LightArmorProficiency);
            subject.AddFeature(Feature.MediumArmorProficiency);
            subject.AddFeature(Feature.HeavyArmorProficiency);
            subject.AddFeature(Feature.ShieldProficiency);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
