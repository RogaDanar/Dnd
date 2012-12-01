namespace Dnd.Core.Saves
{
    public class PoorSaveBonus : ISaveBonus
    {
        public int GetValue(int level) {
            return level / 3;
        }
    }
}
