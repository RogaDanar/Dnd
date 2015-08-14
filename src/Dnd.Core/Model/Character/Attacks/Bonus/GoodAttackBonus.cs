namespace Dnd.Core.Model.Character.Attacks.Bonus
{
    public class GoodAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return level;
        }
    }
}
