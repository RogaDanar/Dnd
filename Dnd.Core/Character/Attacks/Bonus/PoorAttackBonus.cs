namespace Dnd.Core.Character.Attacks.Bonus
{
    public class PoorAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return level / 2;
        }
    }
}
