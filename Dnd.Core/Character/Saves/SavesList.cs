using System.Collections.Generic;
using System.Linq;

namespace Dnd.Core.Character.Saves
{
    public class SavesList
    {
        private readonly DefaultCharacter _character;

        public Dictionary<SaveType, int> Bonusses { get; private set; }

        public int Fortitude { get { return _character.Classes.Sum(x => x.Value.FortitudeSave.Value) + Bonusses[SaveType.Fortitude]; } }
        public int Reflex { get { return _character.Classes.Sum(x => x.Value.ReflexSave.Value) + Bonusses[SaveType.Reflex]; } }
        public int Will { get { return _character.Classes.Sum(x => x.Value.WillSave.Value) + Bonusses[SaveType.Will]; } }

        public SavesList(DefaultCharacter character) {
            _character = character;
            Bonusses = new Dictionary<SaveType, int> { { SaveType.Fortitude, 0 }, { SaveType.Reflex, 0 }, { SaveType.Will, 0 } };
        }

        public void AddBonus(SaveType saveType, int amount) {
            Bonusses[saveType] += amount;
        }
    }
}
