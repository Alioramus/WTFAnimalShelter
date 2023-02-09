using System;
using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class AddAnimalWindow
{
    private readonly ShelterContext _context;
    
    public AddAnimalWindow()
    {
        InitializeComponent();
        using var scope = App.AppContainer.BeginLifetimeScope();
        _context = scope.Resolve<ShelterContext>();
        AnimalBorn.SelectedDate = DateTime.Now;
    }
    
    private void AddAnimal(object sender, RoutedEventArgs e)
    {
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
        _context.Animals.Add(animal);
        _context.SaveChanges();
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