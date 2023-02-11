using System.Windows;
using Autofac;

namespace AnimalShelter;

public partial class VeterinaryRequestWindow
{
    private readonly ShelterContext _shelterContext;
    public VeterinaryRequest VeterinaryRequest { get; set; }

    public VeterinaryRequestWindow(VeterinaryRequest veterinaryRequest)
    {
        InitializeComponent();
        _shelterContext = App.AppContainer.Resolve<ShelterContext>();
        VeterinaryRequest = veterinaryRequest;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        VeterinaryRequest.Description = Description.Text;
        VeterinaryRequest.Reason = Reason.Text;
        _shelterContext.VeterinaryRequests.Update(VeterinaryRequest);
        _shelterContext.SaveChanges();
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}