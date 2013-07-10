namespace Dnd.Core.Character.Saves
{
    public class PoorSaveBonus : ISaveBonus
    {
        public int GetValue(int level) {
            return level / 3;
        }
    }
}
