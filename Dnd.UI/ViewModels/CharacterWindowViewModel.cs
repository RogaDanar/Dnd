namespace Dnd.UI.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Dnd.Core.Character;
    using Dnd.Core.Character.Attributes;
    using Dnd.Core.Character.Modifiers;
    using Dnd.Core.Classes;
    using Dnd.Core.Races;

    public class CharacterWindowViewModel : INotifyPropertyChanged
    {
        private DefaultCharacter _character;
        public DefaultCharacter Character {
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
