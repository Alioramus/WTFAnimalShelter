using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class Keeper
{
    [Key] public int KeeperId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public User User { get; set; }

    public override string ToString() => $"{FirstName} {LastName}";


    public Keeper()
    {
    }


    public void RegisterVisit()
    {
    }
}