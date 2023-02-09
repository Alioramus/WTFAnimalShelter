using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Animals
{
    public class AnimalsListModel
    {
        public List<Animal> Animals { get; set; }
        public AnimalsListModel(ShelterContext context)
        {
            Animals = context.Animals.ToList();
        }

    }
}
