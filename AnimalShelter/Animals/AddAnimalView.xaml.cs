using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AnimalShelter.Animals;

/// <summary>
/// Logika interakcji dla klasy AddAnimalView.xaml
/// </summary>
public partial class AddAnimalView
{
    public AddAnimalView()
    {
        InitializeComponent();
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
            AdoptedBy = AdoptedBy.Text,
        };
        var model = DataContext as AnimalsModel;
        model.AddAnimal(animal);
        MessageBox.Show("Animal added successfully.");
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = NumberRegex();
        e.Handled = regex.IsMatch(e.Text);
    }

    [GeneratedRegex("[^0-9]+")]
    private static partial Regex NumberRegex();
}