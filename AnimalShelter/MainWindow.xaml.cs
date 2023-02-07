using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AnimalShelter;

public partial class MainWindow
{
    public List<Animal> Animals { get; set; }
    public List<Keeper> Keepers { get; set; }
    public List<Visit> Visits { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        using var context = new ShelterContext();
        // context.Database.EnsureDeleted(); // uncomment to delete the database
        context.Database.EnsureCreated();
        Animals = context.Animals.ToList();
        Keepers = context.Keepers.ToList();
        Visits = context.Visits.ToList();
        DataContext = this;
    }
    
    // TODO: otwieranie odpowiedniego okna na podstawie zalogowanej roli - App możę wtedy mieć entrypoint tutaj
    // public MainWindow(UserRole Role)
    // {
    //     Content = Role switch
    //     {
    //         UserRole.Administrator => new AdminWindow(),
    //         UserRole.Keeper => new KeeperWindow(),
    //         UserRole.Veterinarian => new VetWindow(),
    //         _ => new LoginWindow()
    //     };
    // }

    private void ShowAnimalsView(object sender, RoutedEventArgs e)
    {
        if (Animals.Count == 0)
        {
            MessageBox.Show("No animals in the shelter");
            return;
        }

        var animalsWindow = new AnimalsWindow(Animals[0]);
        animalsWindow.Show();
        // ContentFrame.Navigate(animalsWindow);
    }

    private void ShowKeeperView(object sender, RoutedEventArgs e)
    {
        if (Keepers.Count == 0)
        {
            MessageBox.Show("No keepers in the shelter");
            return;
        }

        var keeperWindow = new KeeperWindow(Keepers[0]);
        keeperWindow.Show();
        // ContentFrame.Navigate(keeperWindow);
    }    
    
    private void ShowVisitsView(object sender, RoutedEventArgs e)
    {
        if (Visits.Count == 0)
        {
            MessageBox.Show("No keepers in the shelter");
            return;
        }

        var visitWindow = new VisitWindow(Visits[0]);
        visitWindow.Show();
        // ContentFrame.Navigate(keeperWindow);
    }
}