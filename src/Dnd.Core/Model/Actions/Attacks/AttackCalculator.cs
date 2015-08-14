namespace Dnd.Core.Model.Actions.Attacks
{
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Items.Weapons;

    public class AttackCalculator
    {
        public IWeapon Weapon { get { return Attacker.Equipment.GetEquipedWeapon(); } }
        public bool Surprise { get; private set; }

        public ICharacter Attacker { get; private set; }
        public ICharacter Defender { get; private set; }

        public AttackCalculator(ICharacter attacker, ICharacter defender, bool flatFooted = false)
        {
            Attacker = attacker;
            Defender = defender;
            Surprise = flatFooted;
        }

        public bool IsHit(int attackRoll)
        {
            return attackRoll >= Defender.AC(Surprise);
        }

        public bool IsPossibleCritical(int attackRoll)
        {
            return attackRoll >= Weapon.CritRange;
        }

        public bool IsAutomaticHit(int attackRoll)
        {
            return attackRoll == 20;
        }

        public int GetCriticalDamage()
        {
            return GetDamage(Weapon.CritMultiplier);
        }

        public int GetDamage(int multiplier = 1)
        {
            var damage = 0;
            for (int i = 0; i < multiplier; i++)
            {
                foreach (var damageDie in Weapon.DamageDice)
                {
                    damage += damageDie.Roll();
                }
            }
            damage += multiplier * getDamageBonus();
            return damage;
        }

        private int getDamageBonus()
        {
            switch (Weapon.Type)
            {
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
