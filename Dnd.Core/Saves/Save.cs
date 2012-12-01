namespace Dnd.Core.Saves
{
    public class Save : ReadOnlySave
    {
        public Save(ISaveBonus baseBonus, int level = 1)
            : base(baseBonus, level) {
        }

        public void AdjustBaseBonus(ISaveBonus baseBonus) {
            _baseBonus = baseBonus;
        }

        public void IncreaseLevel() {
            _level++;
        }

        public void AdjustBonus(int value) {
            _bonus += value;
        }

        public static implicit operator int(Save save) {
            return save.Value;
        }

        public static implicit operator string(Save save) {
            return save.Value.ToString();
        }
    }
}
