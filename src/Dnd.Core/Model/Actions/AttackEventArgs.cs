namespace Dnd.Core.Model.Actions
{
    using System;
    using Dnd.Core.Model.Character;

    public class AttackEventArgs : EventArgs
    {
        public string CharacterName { get; set; }
        public AttackResultType AttackResult { get; set; }
        public int Damage { get; set; }

        public AttackEventArgs(ICharacter character, AttackResult attackResult) {
            CharacterName = character.Name;
            AttackResult = attackResult.Type;
            Damage = attackResult.Damage;
        }
    }
}
