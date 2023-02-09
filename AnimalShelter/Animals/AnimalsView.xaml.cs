using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalShelter.Animals
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class AnimalsView : UserControl
    {
        public AnimalsView()
        {
            InitializeComponent();
            this.contentControl.Content = new AnimalListView();
        }

        private void ShowAddAnimal(object sender, RoutedEventArgs e)
        {
           this.contentControl.Content = new AddAnimalView();
        }

        private void ShowListAnimals(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AnimalListView();
        }
    }
}
