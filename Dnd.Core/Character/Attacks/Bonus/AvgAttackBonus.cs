namespace Dnd.Core.Character.Attacks.Bonus
{
    public class AvgAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return (int)(3 * ((double)level / 4));
        }
    }
}
