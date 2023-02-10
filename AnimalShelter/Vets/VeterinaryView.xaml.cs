using System.Windows;
using AnimalShelter.Animals;

namespace AnimalShelter;

public partial class VeterinaryView
{
    public VeterinaryView()
    {
        InitializeComponent();
    }

    private void ShowOpenRequests(object sender, RoutedEventArgs e)
    {
        ContentControl.Content = new VeterinaryRequestsView();
    }

    private void ShowVeterinaryRequests(object sender, RoutedEventArgs e)
    {
        ContentControl.Content = new VeterinaryPanelView();
    }

    private void EditVetDetails(object sender, RoutedEventArgs e)
    {
        var vetDetailsWindow = new VetDetailsWindow(App.CurrentVet);
        vetDetailsWindow.Show();
    }
}