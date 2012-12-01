namespace Dnd.Core.Attacks
{
    public class AvgAttackBonus : IAttackBonus
    {
        public int GetValue(int level) {
            return (int)(3 * ((double)level / 4));
        }
    }
}
