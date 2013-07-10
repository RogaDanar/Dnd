﻿namespace Dnd.Core.Classes.Modifiers
{
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Character.Saves;

    public abstract class AbstractClassModifier : IClassModifier
    {
        public abstract ClassType ClassType { get; }

        public abstract int HitDie { get; }
        public abstract SaveBonusType FortitudeSaveType { get; }
        public abstract SaveBonusType ReflexSaveType { get; }
        public abstract SaveBonusType WillSaveType { get; }
        public abstract AttackBonusType AttackBonusType { get; }
        public abstract int GetSkillPointsCreation(DefaultCharacter subject);
        public abstract int GetSkillPointsLevel(DefaultCharacter subject);

        public virtual void ModifyOnCreation(DefaultCharacter subject) {
            subject.HpMax = HitDie + subject.Constitution.Modifier;
            subject.HpCurrent = subject.HpMax;
            subject.AddSkillPoints(GetSkillPointsCreation(subject));
        }

        public virtual void ModifyOnLevel(DefaultCharacter subject) {
            increaseScores(subject);
        }

        public virtual void ModifyOnMultiClass(DefaultCharacter subject) {
            increaseScores(subject);
        }

        protected void increaseScores(DefaultCharacter subject) {
            var hpGain = getHpGain(subject);
            subject.HpMax += hpGain;
            subject.HpCurrent += hpGain;
            subject.AddSkillPoints(GetSkillPointsLevel(subject));
        }

        protected virtual int getHpGain(DefaultCharacter subject) {
            // HitDie / 2 means it is only the max of the die divided by 2. This is not the mean value of a die throw. The CharacterLevel % 2
            // compensates for this. in case of a odd level an extra hp is added, so over 2 levels the mean is correct
            var hp = subject.Constitution.Modifier + HitDie / 2 + subject.Level % 2;
            // At least 1 hp is gained at a level
            var hpGain = hp > 0 ? hp : 1;
            return hpGain;
        }
    }
}