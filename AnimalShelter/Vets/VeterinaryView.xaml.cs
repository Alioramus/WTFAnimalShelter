using System.Windows;

namespace AnimalShelter;

public partial class VeterinaryView
{
    public VeterinaryView()
    {
        InitializeComponent();
    }

    private void ShowOpenRequests(object sender, RoutedEventArgs e)
    {
        var model = DataContext as VeterinaryModel;
        model.SelectedRequest = null;
        ContentControl.Content = new VeterinaryRequestsView();
    }

    private void ShowVeterinaryRequests(object sender, RoutedEventArgs e)
    {
        var model = DataContext as VeterinaryModel;
        model.SelectedOpenRequest = null;
        ContentControl.Content = new VeterinaryPanelView();
    }

    private void EditVetDetails(object sender, RoutedEventArgs e)
    {
        var vetDetailsWindow = new VetDetailsWindow(App.CurrentVet);
        vetDetailsWindow.DataContext = DataContext;
        vetDetailsWindow.Show();
    }

    private void AssignRequest(object sender, RoutedEventArgs e)
    {
        var model = DataContext as VeterinaryModel;
        model.AddRequest();
    }

    private void CloseRequest(object sender, RoutedEventArgs e)
    {
        var model = DataContext as VeterinaryModel;
        model.CloseRequest();
    }

    private void EditRequestDetails(object sender, RoutedEventArgs e)
    {
        var model = DataContext as VeterinaryModel;
        model.EditRequestDetails();
    }
}