using System;
using System.ComponentModel.DataAnnotations;

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
}

public enum Gender
{
    Male,
    Female
}