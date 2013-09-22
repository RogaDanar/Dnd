namespace Dnd.Core.Actions.Attacks
{
    using System.Collections.Generic;
    using Dnd.Core.Character;

    class MeleeAttack : AbstractAttackAction
    {
        public MeleeAttack(DefaultCharacter attacker, DefaultCharacter defender, int attack, bool flatFooted = false) {
            Attacker = attacker;
            Defender = defender;
            Attack = attack;
            _surprise = flatFooted;
        }

        public override IEnumerable<AttackResult> Execute() {
            var attackRoll = _d20.Roll();
            var attackModifier = Attack;

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
