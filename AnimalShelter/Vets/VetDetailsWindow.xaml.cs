using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class VetDetailsWindow
{
    private readonly ShelterContext _context;
    
    public Vet Vet { get; set; }
    
    public VetDetailsWindow(Vet vet)
    {
        InitializeComponent();
        _context = App.AppContainer.Resolve<ShelterContext>();
        Vet = vet;
        FirstNameText.Text = Vet.Name;
        LastNameText.Text = Vet.Surname;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        Vet.Name = FirstNameText.Text;
        Vet.Surname = LastNameText.Text;
        _context.Vets.Update(Vet);
        _context.SaveChanges();
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}