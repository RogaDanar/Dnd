namespace Dnd.Core.Modifiers.Classes
{
    using Dnd.Core.Enums;

    public abstract class AbstractClassModifier : IModifier<Character>
    {
        protected Character _character { get; set; }

        public abstract int HitDie { get; }
        public abstract SaveBonusType FortitudeSaveType { get; }
        public abstract SaveBonusType ReflexSaveType { get; }
        public abstract SaveBonusType WillSaveType { get; }
        public abstract AttackBonusType AttackBonusType { get; }
        public abstract int SkillPointsCreation { get; }
        public abstract int SkillPointsLevel { get; }

        public virtual void ModifyOnCreation(Character subject) {
            _character = subject;

            _character.HpMax = HitDie + _character.Constitution.Modifier;
            _character.HpCurrent = _character.HpMax;
            _character.SetSaveBonus(FortitudeSaveType, ReflexSaveType, WillSaveType);
            _character.SetAttackBonus(AttackBonusType);
            _character.AddSkillPoints(SkillPointsCreation);
        }

        public virtual void ModifyOnLevel(Character subject) {
            _character = subject;

            var hp = HitDie / 2 + _character.Constitution.Modifier + _character.Level % 2;
            var hpGain = hp > 0 ? hp : 1;
            _character.HpMax += hpGain;
            _character.HpCurrent += hpGain;
            _character.IncreaseSaveLevel();
            _character.IncreaseAttackLevel();
            _character.AddSkillPoints(SkillPointsLevel);
        }
    }
}
