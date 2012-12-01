namespace Dnd.Core.Attacks
{
    public class Attack : ReadOnlyAttack
    {
        public Attack(IAttackBonus baseBonus, int attackNumber, int level = 1)
            : base(baseBonus, attackNumber, level) {
        }

        public void AdjustBaseBonus(IAttackBonus baseBonus) {
            _baseBonus = baseBonus;
        }

        public void IncreaseLevel() {
            _level++;
        }

        public void AdjustBonus(int value) {
            _bonus += value;
        }

        public static implicit operator int(Attack save) {
            return save.Value;
        }

        public static implicit operator string(Attack save) {
            return save.Value.ToString();
        }
    }
}
