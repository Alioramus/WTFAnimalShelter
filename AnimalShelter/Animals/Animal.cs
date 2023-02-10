using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnimalShelter;

public class Animal
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Species Species { get; set; }
    public Gender Gender { get; set; }
    public Size Size { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }
    public bool Adopted { get; set; }
    public string AdoptedBy { get; set; }

    public void Update(ShelterContext context)
    {
        var animal = context.Animals.FirstOrDefault(a => a.Id == Id);

        if (animal != null)
        {
            animal.Name = Name;
            animal.Species = Species;
            animal.Gender = Gender;
            animal.Age = Age;
            animal.Size = Size;
            animal.Description = Description;
            animal.AdoptedBy = AdoptedBy;

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
public enum Species
{
    Dog,
    Cat,
    Bird,
    Other
}
public enum Size
{
    Big,
    Small,
    Medium
}
public enum Gender
{
    Male,
    Female
}