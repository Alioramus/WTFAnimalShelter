using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class MainWindow
{
    private readonly ShelterContext _context;
    public List<Animal> Animals { get; set; }
    public List<Keeper> Keepers { get; set; }
    public List<Visit> Visits { get; set; }
    public List<Vet> Vets { get; set; }
    public List<VeterinaryRequest> VeterinaryRequests { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        _context = App.AppContainer.Resolve<ShelterContext>();
        Keepers = _context.Keepers.ToList();
        Visits = _context.Visits.ToList();
        Vets = _context.Vets.ToList();
        VeterinaryRequests = _context.VeterinaryRequests.ToList();

        DataContext = new NavigationViewModel(_context);
        if (App.CurrentUser is { Role: UserRole.Veterinarian })
        {
            VeterinaryButton.Visibility = Visibility.Visible;
            VeterinaryButton.IsEnabled = true;
        }
    }

    //TODO: otwieranie odpowiedniego okna na podstawie zalogowanej roli - App możę wtedy mieć entrypoint tutaj
    /*
    public MainWindow(UserRole Role)
    {
        Content = Role switch
        {
            UserRole.Administrator => new AdminWindow(),
            UserRole.Keeper => new KeeperWindow(keeper),
            UserRole.Veterinarian => new VetWindow(),
            _ => new LoginWindow()
        };
    }*/
}