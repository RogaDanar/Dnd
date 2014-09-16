namespace Dnd.Core.Model.Actions.Attacks
{
    using Dnd.Core.Model.Dice;
    using System.Collections.Generic;

    public class MeleeAttack : IAction<AttackResult>
    {
        private D20 _d20 = DiceBag.GetDie<D20>();

        private AttackCalculator _calculator;

        public int Attack { get; private set; }

        public MeleeAttack(AttackCalculator calculator, int attackScore)
        {
            _calculator = calculator;
            Attack = attackScore;
        }

        private AttackResult miss()
        {
            return new AttackResult { Type = AttackResultType.Miss, Damage = 0 };
        }

        private AttackResult normalAttack()
        {
            var damage = _calculator.GetDamage();
            return new AttackResult { Type = AttackResultType.Hit, Damage = damage };
        }

        private AttackResult criticalAttack()
        {
            var damage = _calculator.GetCriticalDamage();
            return new AttackResult { Type = AttackResultType.CriticalHit, Damage = damage };
        }

        public IEnumerable<AttackResult> Execute()
        {
            var attackRoll = _d20.Roll();
            var attackModifier = Attack;

            if (_calculator.IsPossibleCritical(attackRoll))
            {
                if (_calculator.IsAutomaticHit(attackRoll) || _calculator.IsHit(attackRoll + attackModifier))
                {
                    var critRoll = _d20.Roll();
                    if (_calculator.IsHit(critRoll + attackModifier))
                    {
                        yield return criticalAttack();
                    }
                    else
                    {
                        yield return normalAttack();
                    }
                }
                else
                {
                    yield return miss();
                }
            }
            else if (_calculator.IsHit(attackRoll + attackModifier))
            {
                yield return normalAttack();
            }
            else
            {
                yield return miss();
            }
        }
    }
}
