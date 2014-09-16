namespace Dnd.Core.Model.Character
{
    using System;
    using System.Linq;

    public class Experience
    {
        private readonly DefaultCharacter _character;

        public int Current { get; private set; }

        public int Level { get { return _character.Classes.Sum(x => x.Value.Level); } }

        // MaxLevel is derived from the experience:  maxLvl = 1/2 + 1/2sqrt(1+xp/125) 
        public int MaxLevel { get { return (int)Math.Floor((1f + Math.Sqrt(1f + ((double)Current / 125f))) / 2f); } }

        public int UnusedLevels { get { return MaxLevel - Level; } }

        public bool CanLevel { get { return UnusedLevels > 0; } }

        private Experience() {

        }

        public Experience(DefaultCharacter character) {
            _character = character;
            Current = 0;
        }

        public void Add(int amount) {
            Current += amount;
        }

        /// <summary>
        /// Sets the character experience to the amount needed for the next level. 
        /// TODO: implement multiclassing
        /// </summary>
        public void SetToNextLevel() {
            Current = (MaxLevel + 1) * (MaxLevel) * 500;
        }

        /// <summary>
        /// Adds experience to gain the given amount of levels
        /// </summary>
        public void AddForNextLevels(int levels) {
            while (levels > 1) {
                SetToNextLevel();
                levels--;
            }
        }
    }
}
