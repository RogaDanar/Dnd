namespace Dnd.Core.Model.Character.Skills
{
    public class Skill : ReadOnlySkill
    {
        public Skill(SkillType type, string subSkill = null)
            : base(type, subSkill) {
        }

        public void Increase(int points) {
            Ranks += points;
        }

        public void IncreaseModifier(int points) {
            MiscModifier += points;
        }
    }
}
