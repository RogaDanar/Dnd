namespace Dnd.Core.Actions.Attacks
{
    using System.Collections.Generic;
    using Dnd.Core.Character;

    class FullAttack : AbstractAttackAction
    {
        public FullAttack(DefaultCharacter attacker, DefaultCharacter defender, bool flatFooted = false) {
            Attacker = attacker;
            Defender = defender;
            _flatFooted = flatFooted;
        }

        public override IEnumerable<AttackResult> Execute() {
            var result = new List<AttackResult>();
            foreach (var attack in Attacker.GetAttacks(_weapon.Type)) {
                var singleAttack = new MeleeAttack(Attacker, Defender, attack);
                result.AddRange(singleAttack.Execute());
            }
            return result;
        }
    }
}
