namespace Dnd.Core.Actions
{
    using System;
    using Dnd.Core.Character;

    public class AttackEventArgs : EventArgs
    {
        public string CharacterName { get; set; }
        public AttackResultType AttackResult { get; set; }
        public int Damage { get; set; }

        public AttackEventArgs(DefaultCharacter character, AttackResult attackResult) {
            CharacterName = character.Name;
            AttackResult = attackResult.Type;
            Damage = attackResult.Damage;
        }
    }
}
