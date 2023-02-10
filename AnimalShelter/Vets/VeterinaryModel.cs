using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter;

public class VeterinaryModel
{
    public List<Animal> Animals { get; set; }
    public List<ShelterAction> Actions { get; set; }
    public List<ShelterAction> VeterinaryActionsToTake { get; set; }
    public List<VeterinaryRequest> Requests { get; set; }
    private User _user;
    
    public VeterinaryModel(ShelterContext context)
    {
        Animals = context.Animals.ToList();
        Actions = context.Actions.ToList();
        VeterinaryActionsToTake = context.Actions.Where(element => element.Type == ShelterActionType.VetVisit && element.Status == ShelterActionStatus.Requested).ToList();
        _user = App.CurrentUser;
        Requests = context.VeterinaryRequests.Where(element => element.Vet.User == _user).ToList();
    }
}