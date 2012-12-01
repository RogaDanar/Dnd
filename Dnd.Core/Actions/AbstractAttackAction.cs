namespace Dnd.Core.Actions
{
    using System.Collections.Generic;
    using Dnd.Core.Dice;
    using Dnd.Core.Enums;
    using Dnd.Core.Items.Weapons;

    public abstract class AbstractAttackAction : IAction<AttackResult>
    {
        protected D20 _d20 = Dice.GetDie<D20>();

        protected IWeapon _weapon { get { return Attacker.GetWeapon(); } }

        public Character Attacker { get; protected set; }

        public Character Defender { get; protected set; }

        public abstract IEnumerable<AttackResult> Execute();

        protected AttackResult Miss() {
            return new AttackResult() { Attack = AttackResultType.Miss, Damage = 0 };
        }

        protected AttackResult NormalAttack() {
            var damage = GetDamage();
            return new AttackResult() { Attack = AttackResultType.Hit, Damage = damage };
        }

        protected AttackResult CriticalAttack() {
            var damage = CriticalDamage();
            return new AttackResult() { Attack = AttackResultType.CriticalHit, Damage = damage };
        }

        protected virtual bool IsHit(int attackRoll) {
            return attackRoll >= Defender.AC;
        }

        protected bool IsPossibleCritical(int attackRoll) {
            return attackRoll >= _weapon.CritRange;
        }

        protected bool IsAutomaticHit(int attackRoll) {
            return attackRoll == 20;
        }

        protected virtual int CriticalDamage() {
            return _weapon.CritMultiplier * GetDamage();
        }

        protected virtual int GetDamage() {
            var damage = 0;
            foreach (var damageDie in _weapon.DamageDice) {
                damage += damageDie.Roll();
            }
            damage += GetDamageBonus();
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
