using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnimalShelter.Animals
{
    public class AnimalsModel : INotifyPropertyChanged
    {
        public List<Animal> Animals { get; private set; }
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
                OnPropertyChanged("SelectedAnimal");
            }
        }

        private ShelterContext context;
        public AnimalsModel(ShelterContext context)
        {
            Animals = context.Animals.ToList();
            this.context = context;
        }

        public void AddAnimal(Animal animal)
        {
            this.context.Animals.Add(animal);
            context.SaveChanges();
            Animals = context.Animals.ToList();
            OnPropertyChanged("Animals");
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
