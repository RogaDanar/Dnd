namespace Dnd.Core.Attacks
{
    public class PoorAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return level / 2;
        }
    }
}
