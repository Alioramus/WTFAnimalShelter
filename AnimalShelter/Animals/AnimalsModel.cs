using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnimalShelter.Animals
{
    public class AnimalsModel
    {
        public List<Animal> Animals { get; set; }

        public ShelterContext context;
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
        }

    }
}
