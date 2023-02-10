using System;
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
            get
            {
                return animals;
            }
            private set
            {
                animals = value;
                OnPropertyChanged("Animals");
            }
        }

        private Animal? selectedAnimal;
        public Animal? SelectedAnimal
        {
            get
            {
                return selectedAnimal;
            }
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
            get
            {
                return request;
            }
            set
            {
                request= value;
                OnPropertyChanged("Request");
            }
        }
        private List<ShelterAction> selectedAnimalActions;
        public List<ShelterAction> SelectedAnimalActions
        {
            get
            {
                return selectedAnimalActions;
            }
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
            this.context.Animals.Add(animal);
            context.SaveChanges();
            Animals = context.Animals.ToList();
        }

        private void deleteAnimal(object sender)
        {
            this.context.Animals.Remove(SelectedAnimal);
            context.SaveChanges();
            Animals = context.Animals.ToList();
            SelectedAnimal= null;
        }

        private void makeRequest(object request)
        {
            var shelterReq = request as ActionRequest;
            context.Actions.Add(new ShelterAction
            {
                Name = shelterReq.Name,
                Description = shelterReq.Description,
                Type = shelterReq.Type,
                AssigneeId = shelterReq.AssigneeId,
                Status = ShelterActionStatus.Requested,
                AnimalId = SelectedAnimal.Id
            });
            context.SaveChanges();
            Request = new ActionRequest();
            SelectedAnimalActions = getSelectedAnimalActions();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }

        private List<ShelterAction> getSelectedAnimalActions()
        {
            return context.Actions.Where(x => x.AnimalId == selectedAnimal.Id).ToList();
        }
    }
}
