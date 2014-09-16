namespace Dnd.Core.Model.Items.Weapons
{
    using Dnd.Core.Model.Character;

    public class Greatsword : AbstractTwoHandedWeapon
    {
        public override string Name { get { return "Greatsword"; } }

        public override WeaponClass Class { get { return WeaponClass.Martial; } }

        public override int CritRange { get { return 19; } }

        public override int CritMultiplier { get { return 2; } }

        public Greatsword(Size size) {
            Size = size;
            DamageTier = 6;
        }
    }
}
