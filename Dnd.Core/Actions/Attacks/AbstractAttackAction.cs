namespace Dnd.Core.Actions.Attacks
{
    using System.Collections.Generic;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attacks;
    using Dnd.Core.Dice;
    using Dnd.Core.Items;

    public abstract class AbstractAttackAction : IAction<AttackResult>
    {
        protected D20 _d20 = DiceBag.GetDie<D20>();

        protected IWeapon _weapon { get { return Attacker.GetWeapon(); } }
        protected bool _surprise { get; set; }

        public DefaultCharacter Attacker { get; protected set; }
        public DefaultCharacter Defender { get; protected set; }
        public int Attack { get; protected set; }

        public abstract IEnumerable<AttackResult> Execute();

        protected AttackResult Miss() {
            return new AttackResult() { Type = AttackResultType.Miss, Damage = 0 };
        }

        protected AttackResult NormalAttack() {
            var damage = GetDamage();
            return new AttackResult() { Type = AttackResultType.Hit, Damage = damage };
        }

        protected AttackResult CriticalAttack() {
            var damage = CriticalDamage();
            return new AttackResult() { Type = AttackResultType.CriticalHit, Damage = damage };
        }

        protected virtual bool IsHit(int attackRoll) {
            return attackRoll >= Defender.GetAc(_surprise);
        }

        protected bool IsPossibleCritical(int attackRoll) {
            return attackRoll >= _weapon.CritRange;
        }

        protected bool IsAutomaticHit(int attackRoll) {
            return attackRoll == 20;
        }

        protected virtual int CriticalDamage() {
            return GetDamage(_weapon.CritMultiplier);
        }

        protected virtual int GetDamage(int multiplier = 1) {
            var damage = 0;
            for (int i = 0; i < multiplier; i++) {
                foreach (var damageDie in _weapon.DamageDice) {
                    damage += damageDie.Roll();
                }
            }
            damage += multiplier * GetDamageBonus();
            return damage;
        }

        protected virtual int GetDamageBonus() {
            switch (_weapon.Type) {
                case WeaponType.TwoHanded:
                    return (int)1.5 * (Attacker.Strength.Modifier);
                case WeaponType.OneHanded:
                    return Attacker.Strength.Modifier;
                case WeaponType.Ranged:
                default:
                    return 0;
            }
        }
    }
}
