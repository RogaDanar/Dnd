

namespace Dnd.UI
{
    using System.Windows;
    using Dnd.UI.ViewModels;

    public partial class MainWindow : Window
    {
        private readonly CharacterWindowViewModel _viewModel;
        //private DefaultCharacter _character;

        public MainWindow() {
            InitializeComponent();
            _viewModel = new CharacterWindowViewModel();
            DataContext = _viewModel;
        }

        private void ButtonCreateClick(object sender, RoutedEventArgs e) {
            _viewModel.CreateCharacter();

            LvlBtn.Visibility = Visibility.Visible;
        }

        private void LvlBtnClick(object sender, RoutedEventArgs e) {
            _viewModel.SetCharacterToNextLevel();
        }
    }
}
