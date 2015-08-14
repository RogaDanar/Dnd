namespace Dnd.Core.Model.Character.Saves
{
    public class Save
    {
        public SaveType Type { get; private set; }
        protected ISaveBonus _baseBonus;
        protected int _level;
        public int Value { get { return _baseBonus.GetValue(_level); } }

        public Save(ISaveBonus baseBonus, int level = 1) {
            _baseBonus = baseBonus;
            _level = level;
        }

        public static implicit operator int(Save save) {
            return save.Value;
        }

        public static implicit operator string(Save save) {
            return save.Value.ToString();
        }
    }
}
