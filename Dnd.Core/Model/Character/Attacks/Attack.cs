namespace Dnd.Core.Model.Character.Attacks
{
    using Dnd.Core.Model.Character.Attacks.Bonus;

    public class Attack
    {
        public int Value { get { return _baseBonus.GetValue(_level); } }
        protected IAttackBonus _baseBonus;
        protected int _level;

        public Attack(IAttackBonus baseBonus, int level) {
            _baseBonus = baseBonus;
            _level = level;
        }

        public static implicit operator int(Attack attack) {
            return attack.Value;
        }

        public static implicit operator string(Attack attack) {
            return attack.Value.ToString();
        }
    }
}
