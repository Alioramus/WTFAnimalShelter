using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class VeterinaryRequest
{
    [Key]
    public int Id { get; set; }
    public Animal Animal { get; set; }
    public string Reason { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Vet Vet { get; set; }
}