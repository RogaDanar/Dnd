namespace Dnd.Core.Modifiers.Classes
{
    using Dnd.Core.Enums;

    public class RogueModifier : AbstractClassModifier
    {
        public override int HitDie { get { return 6; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Poor; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        public override int SkillPointsCreation { get { return (8 + _character.Intelligence.Modifier) * 4; } }
        public override int SkillPointsLevel { get { return 8 + _character.Intelligence.Modifier; } }

        public override void ModifyOnCreation(Character subject) {
            base.ModifyOnCreation(subject);

            subject.AddFeature(Feature.SimpleWeaponProficiency);
            subject.AddFeature(Feature.LightArmorProficiency);
        }

        public override void ModifyOnLevel(Character subject) {
            base.ModifyOnLevel(subject);
        }
    }
}
