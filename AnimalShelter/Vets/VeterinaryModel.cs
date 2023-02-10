using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AnimalShelter;

public class VeterinaryModel : INotifyPropertyChanged
{
    public List<Animal> Animals { get; set; }

    private List<ShelterAction> _veterinaryRequestsToTake;

    public List<ShelterAction> VeterinaryRequestsToTake
    {
        get => _veterinaryRequestsToTake;
        set
        {
            _veterinaryRequestsToTake = value;
            OnPropertyChanged("VeterinaryActionsToTake");
        }
    }

    private ShelterAction? _selectedRequestToTake;

    public ShelterAction? SelectedRequestToTake
    {
        get => _selectedRequestToTake;
        set
        {
            _selectedRequestToTake = value;
            OnPropertyChanged("SelectedRequestToTake");
        }
    }

    private List<VeterinaryRequest> _requests;

    public List<VeterinaryRequest> Requests
    {
        get => _requests;
        set
        {
            _requests = value;
            OnPropertyChanged("Requests");
        }
    }

    private VeterinaryRequest? _selectedRequest;

    public VeterinaryRequest? SelectedRequest
    {
        get => _selectedRequest;
        set
        {
            _selectedRequest = value;
            OnPropertyChanged("SelectedRequest");
        }
    }

    private User _user;
    private Vet _vet;

    public VeterinaryModel(ShelterContext context)
    {
        Animals = context.Animals.ToList();
        VeterinaryRequestsToTake = context.Actions.Where(element => element.Type == ShelterActionType.VetVisit && element.Status == ShelterActionStatus.Requested).ToList();
        _user = App.CurrentUser;
        _vet = App.CurrentVet;
        Requests = context.VeterinaryRequests.Where(element => element.Vet.User == _user).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}