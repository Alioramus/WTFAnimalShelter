using System.Windows;

namespace AnimalShelter;

public partial class AdminView
{
    public AdminView()
    {
        InitializeComponent();
    }

    private void DeleteAccount(object sender, RoutedEventArgs e)
    {
        var adminModel = DataContext as AdminModel;
        adminModel.DeleteUser();
    }

    private void EditAccount(object sender, RoutedEventArgs e)
    {
        var adminModel = DataContext as AdminModel;
        var editAccountWindow = new EditAccountWindow(adminModel.SelectedUser);
        editAccountWindow.DataContext = adminModel;
        editAccountWindow.Show();
    }
}