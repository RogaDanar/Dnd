namespace Dnd.Core.Model.Items.Weapons
{
    using Dnd.Core.Model.Character;

    public class Longsword : AbstractSingleHandedWeapon
    {
        public override string Name { get { return "Longsword"; } }

        public override WeaponClass Class { get { return WeaponClass.Martial; } }

        public override int CritRange { get { return 19; } }

        public override int CritMultiplier { get { return 2; } }

        public Longsword(Size size) {
            Size = size;
            DamageTier = 6;
        }
    }
}
