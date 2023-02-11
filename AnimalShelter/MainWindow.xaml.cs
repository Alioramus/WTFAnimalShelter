using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class MainWindow
{
    private readonly ShelterContext _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = App.AppContainer.Resolve<ShelterContext>();
        DataContext = new NavigationViewModel(_context);

        switch (App.CurrentUser)
        {
            case { Role: UserRole.Veterinarian }:
                KeeperPanel.Visibility = Visibility.Collapsed;
                VeterinaryPanel.Visibility = Visibility.Visible;
                VeterinaryButton.IsEnabled = true;
                break;
            case { Role: UserRole.Keeper }:
                KeeperPanel.Visibility = Visibility.Visible;
                VeterinaryPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Collapsed;
                break;
            case { Role: UserRole.Administrator }:
                KeeperPanel.Visibility = Visibility.Collapsed;
                VeterinaryPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Visible;
                AdminButton.IsEnabled = true;
                break;
        }
    }
}