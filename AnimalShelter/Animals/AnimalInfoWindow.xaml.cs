using System;
using System.Windows;

namespace AnimalShelter;

public partial class AnimalInfoWindow
{
    private readonly Animal _animal;

    public AnimalInfoWindow(Animal animal)
    {
        InitializeComponent();
        _animal = animal;
        DataContext = _animal;
    }

    private void UpdateAnimalInfo(object sender, RoutedEventArgs e)
    {
        using var context = new ShelterContext();
        try
        {
            _animal.Update(context);
            MessageBox.Show("Animal information updated successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void AdoptAnimal(object sender, RoutedEventArgs e)
    {
        using var context = new ShelterContext();
        try
        {
            _animal.Adopt(context);
            MessageBox.Show("Animal adopted successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}