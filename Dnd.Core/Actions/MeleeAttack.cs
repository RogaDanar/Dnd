namespace Dnd.Core.Actions
{
    using System.Collections.Generic;

    class MeleeAttack : AbstractAttackAction
    {
        private KeyValuePair<int, int> _attack;

        public MeleeAttack(Character attacker, Character defender, KeyValuePair<int, int> attack) {
            Attacker = attacker;
            Defender = defender;
            _attack = attack;
        }

        public override IEnumerable<AttackResult> Execute() {
            var attackRoll = _d20.Roll();
            var attackModifier = _attack.Value;

            if (IsPossibleCritical(attackRoll)) {
                if (IsAutomaticHit(attackRoll) || IsHit(attackRoll + attackModifier)) {
                    var critRoll = _d20.Roll();
                    if (IsHit(critRoll + attackModifier)) {
                        yield return CriticalAttack();
                    } else {
                        yield return NormalAttack();
                    }
                } else {
                    yield return Miss();
                }
            } else if (IsHit(attackRoll + attackModifier)) {
                yield return NormalAttack();
            } else {
                yield return Miss();
            }
        }
    }
}
