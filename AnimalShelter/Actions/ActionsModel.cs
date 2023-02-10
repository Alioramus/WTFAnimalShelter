using AnimalShelter.Animals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AnimalShelter.Actions
{
    public class ActionsModel : INotifyPropertyChanged
    {
        private List<ActionRequest> ActionsRequests { get; set; }
        private List<User> Users { get; set; }
        private ShelterContext context { get; set; }
        public ActionsModel(ShelterContext context)
        {
            ActionsRequests = context.ActionRequests.ToList();
            Users = context.Users.ToList();
            this.context = context;
            Debug.WriteLine("HEJ HEJ: " + ActionsRequests.Count);
            // request = new ActionRequest();
            // DeleteAnimal = new BaseCommand(deleteAnimal);
            // MakeRequest = new BaseCommand(makeRequest);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }
}
