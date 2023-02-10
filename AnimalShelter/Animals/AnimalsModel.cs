using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace AnimalShelter.Animals
{
    public class AnimalsModel : INotifyPropertyChanged
    {
        public List<User> Users { get; set; }
        private List<Animal> animals;
        public List<Animal> Animals
        {
            get => animals;
            private set
            {
                animals = value;
                OnPropertyChanged("Animals");
            }
        }

        private Animal? selectedAnimal;
        public Animal? SelectedAnimal
        {
            get => selectedAnimal;
            set
            {
                selectedAnimal= value;
                if (selectedAnimal != null)
                {
                    SelectedAnimalActions = getSelectedAnimalActions();
                }
                OnPropertyChanged("SelectedAnimal");
            }
        }
        private ActionRequest request;
        public ActionRequest Request
        {
            get => request;
            set
            {
                request= value;
                OnPropertyChanged("Request");
            }
        }
        private List<ShelterAction> selectedAnimalActions;
        public List<ShelterAction> SelectedAnimalActions
        {
            get => selectedAnimalActions;
            set
            {
                selectedAnimalActions= value;
                OnPropertyChanged("SelectedAnimalActions");
            }
        }
        public ICommand DeleteAnimal { get; }
        public ICommand MakeRequest { get; }

        private ShelterContext context;
        public AnimalsModel(ShelterContext context)
        {
            Animals = context.Animals.ToList();
            Users = context.Users.ToList();
            this.context = context;
            request = new ActionRequest();
            DeleteAnimal = new BaseCommand(deleteAnimal);
            MakeRequest = new BaseCommand(makeRequest);
        }

        public void AddAnimal(Animal animal)
        {
            context.Animals.Add(animal);
            context.SaveChanges();
            Animals = context.Animals.ToList();
        }

        private void deleteAnimal(object sender)
        {
            context.Animals.Remove(SelectedAnimal);
            context.SaveChanges();
            Animals = context.Animals.ToList();
            SelectedAnimal= null;
        }

        private void makeRequest(object request)
        {
            var shelterReq = request as ActionRequest;
            context.ActionRequests.Add(shelterReq);
            context.Actions.Add(new ShelterAction
            {
                Name = shelterReq.Name,
                Description = shelterReq.Description,
                Type = shelterReq.Type,
                Assignee = shelterReq.Assignee,
                Status = ShelterActionStatus.Requested,
                Animal = SelectedAnimal
            });
            context.SaveChanges();
            Request = new ActionRequest();
            SelectedAnimalActions = getSelectedAnimalActions();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private List<ShelterAction> getSelectedAnimalActions()
        {
            return context.Actions.Where(x => x.Animal == selectedAnimal).ToList();
        }
    }
}
