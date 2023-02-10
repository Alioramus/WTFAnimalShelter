using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AnimalShelter;

public class VeterinaryModel: INotifyPropertyChanged
{
    public List<Animal> Animals { get; set; }
    public List<ShelterAction> Actions { get; set; }
    public List<VeterinaryRequest> Requests { get; set; }
    private User _user;
    public VeterinaryModel(ShelterContext context)
    {
        Animals = context.Animals.ToList();
        Actions = context.Actions.ToList();
        _user = App.CurrentUser;
        Requests = context.VeterinaryRequests.Where(element => element.Vet.User == _user).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}