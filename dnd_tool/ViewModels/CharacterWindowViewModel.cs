namespace Dnd.UI.ViewModels
{
    using System.ComponentModel;
    using Dnd.Core;

    public class CharacterWindowViewModel : INotifyPropertyChanged
    {
        private Character _character;
        public Character Character {
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
