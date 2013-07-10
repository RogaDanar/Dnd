namespace Dnd.Core
{
    using System;
    using Dnd.Core.Actions;
    using Dnd.Core.Actions.Attacks;
    using Dnd.Core.Character;

    public class Arena
    {
        public event EventHandler<AttackEventArgs> AttackMade;
        private void OnAttackMade(AttackEventArgs e) {
            if (AttackMade != null) {
                AttackMade(this, e);
            }
        }

        public event EventHandler<AttackEventArgs> Attacked;
        private void OnAttacked(AttackEventArgs e) {
            if (Attacked != null) {
                Attacked(this, e);
            }
        }

        public event EventHandler FightDone;
        private void OnFightDone(EventArgs e) {
            if (FightDone != null) {
                FightDone(this, e);
            }
        }

        private readonly DefaultCharacter _character1;
        private readonly DefaultCharacter _character2;

        public Arena(DefaultCharacter character1, DefaultCharacter character2) {
            _character1 = character1;
            _character2 = character2;
        }

        public void StartFight() {
            while (_character1.HpCurrent > 0 && _character2.HpCurrent > 0) {
                if (_character1.HpCurrent > 0) {
                    var results = new FullAttack(_character1, _character2).Execute();
                    foreach (var result in results) {
                        _character2.HpCurrent -= result.Damage;
                        OnAttackMade(new AttackEventArgs(_character1.Name, result.Attack, result.Damage));
                    }
                }
                if (_character2.HpCurrent > 0) {
                    var results = new FullAttack(_character2, _character1).Execute();
                    foreach (var result in results) {
                        _character1.HpCurrent -= result.Damage;
                        OnAttacked(new AttackEventArgs(_character2.Name, result.Attack, result.Damage));
                    }
                }
            }
            OnFightDone(EventArgs.Empty);
        }
    }
}
