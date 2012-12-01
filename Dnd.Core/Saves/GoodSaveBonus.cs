namespace Dnd.Core.Saves
{
    public class GoodSaveBonus : ISaveBonus
    {
        public int GetValue(int level) {
            return 2 + (level / 2);
        }
    }
}
