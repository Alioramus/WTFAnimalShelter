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
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Animals
{
    /// <summary>
    /// Logika interakcji dla klasy AddAnimalView.xaml
    /// </summary>
    public partial class AddAnimalView : UserControl
    {
        public AddAnimalView()
        {
            InitializeComponent();
            // AnimalBorn.SelectedDate = DateTime.Now;
        }
        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            var animal = new Animal
            {
                Name = AnimalName.Text,
                Age = Int32.Parse(AnimalAge.Text),
                Species = (Species)AnimalSpecies.SelectedValue,
                Gender = (Gender)AnimalGender.SelectedValue,
                Description = AnimalDescription.Text,
                Size = (Size)AnimalSize.SelectedValue,
                Adopted = AnimalAdopted.IsChecked ?? false,
                //Keeper = CurrentKeeper.Text,
                //AdoptedBy = AdoptedBy.Text,
            };
            var model = DataContext as AnimalsModel;
            model.AddAnimal(animal);
            MessageBox.Show("Animal added successfully.");
        }
    }
}
