using Dnd.Core.Model.Races;

namespace Dnd.UI.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Dnd.Core.Model.Character;
    using Dnd.Core.Model.Character.Attributes;
    using Dnd.Core.Model.Character.Modifiers;
    using Dnd.Core.Model.Classes;
    using Dnd.Core.Model.Races;

    public class CharacterWindowViewModel : INotifyPropertyChanged
    {
        private ICharacter _character;
        public ICharacter Character {
            get {
                return _character;
            }
            set {
                _character = value;
                RaisePropertyChanged("Character");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal void CreateCharacter() {
            Character = new DefaultCharacter(ClassType.Barbarian, Race.Gnome, new Dictionary<AttributeType, int>(), new ModifierProvider());
        }

        internal void SetCharacterToNextLevel() {
            Character.Experience.SetToNextLevel();
        }
    }
}
