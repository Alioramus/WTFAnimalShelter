using System;
using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class AnimalInfoWindow
{
    private readonly ShelterContext _context;
    private readonly Animal _animal;

    public AnimalInfoWindow(Animal animal)
    {
        InitializeComponent();
        _animal = animal;
        _context = App.AppContainer.Resolve<ShelterContext>();
        DataContext = _animal;
    }

    private void UpdateAnimalInfo(object sender, RoutedEventArgs e)
    {
        try
        {
            _animal.Update(_context);
            MessageBox.Show("Animal information updated successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void AdoptAnimal(object sender, RoutedEventArgs e)
    {
        try
        {
            _animal.Adopt(_context);
            MessageBox.Show("Animal adopted successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}