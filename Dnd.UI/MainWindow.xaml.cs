namespace Dnd.UI
{
    using System.Windows;
    using Dnd.Core;
    using Dnd.UI.ViewModels;

    public partial class MainWindow : Window
    {
        //private CharacterWindowViewModel _viewModel;
        //private Character _character;

        public MainWindow() {
            InitializeComponent();
            //_viewModel = new CharacterWindowViewModel();
            //DataContext = _viewModel;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e) {
            //_character = new Character();
            //_viewModel.Character = _character;

            //lvlBtn.Visibility = Visibility.Visible;
            //            unassignedLbl.Content = _viewModel.Character.UnassignedPoints;
        }

        private void lvlBtn_Click(object sender, RoutedEventArgs e) {
            //_character.SetExperienceToNextLevel();
            //            unassignedLbl.Content = _character.UnassignedPoints;
        }
    }
}
