namespace Dnd.Core.Attacks
{

    public class ReadOnlyAttack
    {
        public int Number { get; private set; }

        protected IAttackBonus _baseBonus;
        protected int _level;
        protected int _bonus;

        public ReadOnlyAttack(IAttackBonus baseBonus, int attackNumber, int level = 1) {
            _baseBonus = baseBonus;
            Number = attackNumber;
            _level = level;
            _bonus = 0;
        }

        public int Value {
            get { return _baseBonus.GetValue(_level) - (Number - 1) * 5 + _bonus; }
        }

        public static implicit operator int(ReadOnlyAttack attack) {
            return attack.Value;
        }

        public static implicit operator string(ReadOnlyAttack attack) {
            return attack.Value.ToString();
        }
    }
}
