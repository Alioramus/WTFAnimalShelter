using System.Windows;

namespace AnimalShelter;

public partial class AnimalsWindow
{
    private readonly Animal _animal;

    public AnimalsWindow(Animal animal)
    {
        InitializeComponent();
        _animal = animal;
        DataContext = _animal;
    }

    private void UpdateAnimalInfo(object sender, RoutedEventArgs e)
    {
        // code to update animal information
    }

    private void AdoptAnimal(object sender, RoutedEventArgs e)
    {
        // code to set animal as adopted
    }
}