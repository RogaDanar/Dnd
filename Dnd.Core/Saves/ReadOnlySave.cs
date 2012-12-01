namespace Dnd.Core.Saves
{
    using Dnd.Core.Enums;

    public class ReadOnlySave
    {
        public SaveType Type { get; private set; }

        protected ISaveBonus _baseBonus;
        protected int _level;
        protected int _bonus;

        public ReadOnlySave(ISaveBonus baseBonus, int level = 1) {
            _baseBonus = baseBonus;
            _level = level;
            _bonus = 0;
        }

        public int Value {
            get { return _baseBonus.GetValue(_level) + _bonus; }
        }

        public static implicit operator int(ReadOnlySave save) {
            return save.Value;
        }

        public static implicit operator string(ReadOnlySave save) {
            return save.Value.ToString();
        }
    }
}
