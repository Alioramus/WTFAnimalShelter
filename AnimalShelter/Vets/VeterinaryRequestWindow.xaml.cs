using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class VeterinaryRequestWindow
{
    private readonly ShelterContext _shelterContext;

    public VeterinaryRequestWindow()
    {
        InitializeComponent();
        _shelterContext = App.AppContainer.Resolve<ShelterContext>();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}