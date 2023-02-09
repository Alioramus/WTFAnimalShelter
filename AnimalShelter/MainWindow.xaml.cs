using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac;

namespace AnimalShelter;

public partial class MainWindow
{
    private readonly ShelterContext _context;
    public List<Animal> Animals { get; set; }
    public List<Keeper> Keepers { get; set; }
    public List<Visit> Visits { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        _context = App.AppContainer.Resolve<ShelterContext>();
        _context.Database.EnsureCreated();
        Keepers = _context.Keepers.ToList();
        Visits = _context.Visits.ToList();
        DataContext = new NavigationViewModel(_context);

        /*
        Keeper someKeeper = new Keeper();
        someKeeper.FirstName = "Jan";
        someKeeper.LastName = "Kowalski";
        someKeeper.KeeperId = 30;
        Window keeperTestWindow = new KeeperWindow(someKeeper);
        keeperTestWindow.Show();
        */
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
    }
    */

    private void ShowAnimalsView(object sender, RoutedEventArgs e)
    {
        if (Animals.Count == 0)
        {
            MessageBox.Show("No animals in the shelter");
            return;
        }

        var animalsWindow = new AnimalInfoWindow(Animals[0]);
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