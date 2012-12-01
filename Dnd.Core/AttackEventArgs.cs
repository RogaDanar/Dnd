namespace Dnd.Core
{
    using System;
    using Dnd.Core.Enums;

    public class AttackEventArgs : EventArgs
    {
        public string PlayerName { get; set; }
        public AttackResultType AttackResult { get; set; }
        public int Damage { get; set; }

        public AttackEventArgs(string playerName, AttackResultType attackResult, int damage) {
            PlayerName = playerName;
            AttackResult = attackResult;
            Damage = damage;
        }
    }
}
