using System;
using System.Windows;

namespace AnimalShelter;

public partial class AddAnimalWindow
{
    public AddAnimalWindow()
    {
        InitializeComponent();
        AnimalBorn.SelectedDate = DateTime.Now;
    }
    
    private void AddAnimal(object sender, RoutedEventArgs e)
    {
        using var context = new ShelterContext();
        var animal = new Animal
        {
            Name = AnimalName.Text,
            Breed = AnimalBreed.Text,
            Species = AnimalSpecies.Text,
            Gender = (Gender) AnimalGender.SelectedValue,
            Born = Convert.ToDateTime(AnimalBorn.Text),
            Description = AnimalDescription.Text,
            Adopted = AnimalAdopted.IsChecked ?? false,
            //Keeper = CurrentKeeper.Text,
            //AdoptedBy = AdoptedBy.Text,
        };
        context.Animals.Add(animal);
        context.SaveChanges();
        MessageBox.Show("Animal added successfully.");
        Close();
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow!.OnAddAnimalEvent();
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
        Close();
    }
}