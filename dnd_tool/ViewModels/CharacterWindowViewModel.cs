using Dnd.Core.Character;

namespace Dnd.UI.ViewModels
{
    using System.ComponentModel;

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
    }
}
