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

        public DefaultCharacter Character1 { get; private set; }
        public DefaultCharacter Character2 { get; private set; }

        public Arena(DefaultCharacter character1, DefaultCharacter character2) {
            Character1 = character1;
            Character2 = character2;
        }

        public void StartFight() {
            while (Character1.Hitpoints.Current > 0 && Character2.Hitpoints.Current > 0) {
                if (Character1.Hitpoints.Current > 0) {
                    var results = new FullAttack(Character1, Character2).Execute();
                    foreach (var result in results) {
                        Character2.Hitpoints.Current -= result.Damage;
                        OnAttackMade(new AttackEventArgs(Character1, result));
                    }
                }
                if (Character2.Hitpoints.Current > 0) {
                    var results = new FullAttack(Character2, Character1).Execute();
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
