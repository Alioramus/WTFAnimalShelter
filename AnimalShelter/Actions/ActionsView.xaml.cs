using System.Windows;

namespace AnimalShelter.Actions
{
    /// <summary>
    /// Interaction logic for ActionsView.xaml
    /// </summary>
    public partial class ActionsView
    {
        public ActionsView()
        {
            InitializeComponent();
            contentControl.Content = new ActionsListView();
        }

        private void ShowActions(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ActionsListView();
        }
    }
}