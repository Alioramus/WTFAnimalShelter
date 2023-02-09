using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnimalShelter;

public class Animal
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public string Species { get; set; }
    public Gender Gender { get; set; }
    public DateTime Born { get; set; }
    public string Description { get; set; }
    public bool Adopted { get; set; }

    public void Update(ShelterContext context)
    {
        var animal = context.Animals.FirstOrDefault(a => a.Id == Id);

        if (animal != null)
        {
            animal.Name = Name;
            animal.Breed = Breed;
            animal.Species = Species;
            animal.Gender = Gender;
            animal.Born = Born;
            animal.Description = Description;

            context.SaveChanges();
        }
        else
        {
            throw new Exception("Animal not found.");
        }
    }

    public void Adopt(ShelterContext context)
    {
        var animal = context.Animals.FirstOrDefault(a => a.Id == Id);

        if (animal != null)
        {
            animal.Adopted = true;
            context.SaveChanges();
        }
        else
        {
            throw new Exception("Animal not found.");
        }
    }
}

public enum Gender
{
    Male,
    Female
}