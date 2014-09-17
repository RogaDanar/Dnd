namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Features;
    using Dnd.Core.Model.Character.Saves;

    public class ClericModifier : ClassModifierTemplate
    {
        public override ClassType ClassType { get { return ClassType.Cleric; } }
        public override SaveBonusType FortitudeSaveType { get { return SaveBonusType.Good; } }
        public override SaveBonusType ReflexSaveType { get { return SaveBonusType.Poor; } }
        public override SaveBonusType WillSaveType { get { return SaveBonusType.Good; } }
        public override AttackBonusType AttackBonusType { get { return AttackBonusType.Average; } }

        protected override int HitDie { get { return 8; } }

        protected override int GetSkillPointsCreation(ICharacter subject) {
            return (2 + subject.Intelligence.Modifier) * 4;
        }

        protected override int GetSkillPointsLevel(ICharacter subject) {
            return 2 + subject.Intelligence.Modifier;
        }

        protected override void ClassModifyOnCreation(ICharacter subject) {
            subject.Features.Add(Feature.SimpleWeaponProficiency);
            subject.Features.Add(Feature.LightArmorProficiency);
            subject.Features.Add(Feature.MediumArmorProficiency);
            subject.Features.Add(Feature.HeavyArmorProficiency);
            subject.Features.Add(Feature.ShieldProficiency);
        }

        protected override void ClassModifyOnLevel(ICharacter subject) {
        }

        protected override void ClassModifyOnMultiClass(ICharacter subject) {
        }
    }
}
