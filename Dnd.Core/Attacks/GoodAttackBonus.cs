namespace Dnd.Core.Attacks
{
    public class GoodAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return level;
        }
    }
}
