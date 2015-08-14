namespace Dnd.Core.Model
{
    using Dnd.Core.Model.Actions;
    using Dnd.Core.Model.Actions.Attacks;
    using Dnd.Core.Model.Character;
    using System;

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

        public ICharacter Character1 { get; private set; }
        public ICharacter Character2 { get; private set; }

        public Arena(ICharacter character1, ICharacter character2) {
            Character1 = character1;
            Character2 = character2;
        }

        public void StartFight() {
            var attackCalculator = new AttackCalculator(Character1, Character2);
            while (Character1.Hitpoints.Current > 0 && Character2.Hitpoints.Current > 0) {
                if (Character1.Hitpoints.Current > 0) {
                    var results = new FullAttack(attackCalculator).Execute();
                    foreach (var result in results) {
                        Character2.Hitpoints.Current -= result.Damage;
                        OnAttackMade(new AttackEventArgs(Character1, result));
                    }
                }
                if (Character2.Hitpoints.Current > 0) {
                    var results = new FullAttack(attackCalculator).Execute();
                    foreach (var result in results) {
                        Character1.Hitpoints.Current -= result.Damage;
                        OnAttacked(new AttackEventArgs(Character2, result));
                    }
                }
            }
            OnFightDone(EventArgs.Empty);
        }
    }
}
