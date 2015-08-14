namespace Dnd.Core.Model.Actions.Attacks
{
    using System.Collections.Generic;

    class FullAttack : IAction<AttackResult>
    {
        private AttackCalculator _calculator;

        public FullAttack(AttackCalculator calculator) {
            _calculator = calculator;
        }

        public IEnumerable<AttackResult> Execute() {
            var result = new List<AttackResult>();
            foreach (var attackScore in _calculator.Attacker.Attacks.GetAttackScores(_calculator.Weapon.Type))
            {
                var singleAttack = new MeleeAttack(_calculator, attackScore);
                result.AddRange(singleAttack.Execute());
            }
            return result;
        }
    }
}
