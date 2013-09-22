namespace Dnd.Core.Items.Weapons
{
    using Dnd.Core.Character;

    public class Greatsword : AbstractTwoHandedWeapon
    {
        public override string Name { get { return "Greatsword"; } }

        public override int CritRange { get { return 19; } }

        public override int CritMultiplier { get { return 2; } }

        public Greatsword(Size size) {
            Size = size;
            DamageTier = 6;
        }
    }
}
