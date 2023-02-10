using System.Windows;

namespace AnimalShelter.Animals
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class AnimalsView
    {
        public AnimalsView()
        {
            InitializeComponent();
            contentControl.Content = new AnimalListView();
        }

        private void ShowAddAnimal(object sender, RoutedEventArgs e)
        {
           contentControl.Content = new AddAnimalView();
        }

        private void ShowListAnimals(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new AnimalListView();
        }

        private void ShowAnimalDetails(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new AnimalDetailsView();
        }
    }
}
