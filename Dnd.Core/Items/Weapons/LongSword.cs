namespace Dnd.Core.Items.Weapons
{
    using Dnd.Core.Character;

    public class Longsword : AbstractSingleHandedWeapon
    {
        public override string Name { get { return "Longsword"; } }

        public override int CritRange { get { return 19; } }

        public override int CritMultiplier { get { return 2; } }

        public Longsword(Size size) {
            Size = size;
            DamageTier = 6;
        }
    }
}
