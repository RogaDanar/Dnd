namespace Dnd.Core.Model.Classes.Modifiers
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attacks;
    using Dnd.Core.Model.Character.Saves;

    /// <summary>
    /// Template Method for class modifiers
    /// </summary>
    public abstract class ClassModifierTemplate : IClassModifier
    {
        public abstract ClassType ClassType { get; }
        public abstract SaveBonusType FortitudeSaveType { get; }
        public abstract SaveBonusType ReflexSaveType { get; }
        public abstract SaveBonusType WillSaveType { get; }
        public abstract AttackBonusType AttackBonusType { get; }

        protected abstract int HitDie { get; }
        protected abstract int GetSkillPointsCreation(ICharacter subject);
        protected abstract int GetSkillPointsLevel(ICharacter subject);

        protected abstract void ClassModifyOnCreation(ICharacter subject);
        protected abstract void ClassModifyOnLevel(ICharacter subject);
        protected abstract void ClassModifyOnMultiClass(ICharacter subject);

        public void ModifyOnCreation(ICharacter subject) {
            subject.Hitpoints.Max = HitDie + subject.Constitution.Modifier;
            subject.Hitpoints.Current = subject.Hitpoints.Max;
            subject.Skills.AddRanks(GetSkillPointsCreation(subject));
            ClassModifyOnCreation(subject);
        }

        public void ModifyOnLevel(ICharacter subject) {
            increaseScores(subject);
            ClassModifyOnLevel(subject);
        }

        public void ModifyOnMultiClass(ICharacter subject) {
            increaseScores(subject);
            ClassModifyOnMultiClass(subject);
        }

        private void increaseScores(ICharacter subject) {
            var hpGain = getHpGain(subject);
            subject.Hitpoints.Max += hpGain;
            subject.Hitpoints.Current += hpGain;
            subject.Skills.AddRanks(GetSkillPointsLevel(subject));
        }

        private int getHpGain(ICharacter subject) {
            // HitDie / 2 means it is only the max of the die divided by 2. This is not the mean value of a die throw. The CharacterLevel % 2
            // compensates for this. in case of a odd level an extra hp is added, so over 2 levels the mean is correct
            var hp = subject.Constitution.Modifier + HitDie / 2 + subject.Experience.Level % 2;
            // At least 1 hp is gained at a level
            var hpGain = hp > 0 ? hp : 1;
            return hpGain;
        }
    }
}
