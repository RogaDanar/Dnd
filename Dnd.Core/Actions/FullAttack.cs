namespace Dnd.Core.Actions
{
    using System.Collections.Generic;

    class FullAttack : AbstractAttackAction
    {
        public FullAttack(Character attacker, Character defender, bool flatFooted = false) {
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
