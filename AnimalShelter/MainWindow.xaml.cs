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
        
        if (App.CurrentUser is { Role: UserRole.Veterinarian })
        {
            KeeperPanel.Visibility = Visibility.Collapsed;
            VeterinaryPanel.Visibility = Visibility.Visible;
            VeterinaryButton.IsEnabled = true;
        }
    }
}