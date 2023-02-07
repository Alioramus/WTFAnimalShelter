using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

/// <summary>
/// Visit information
/// </summary>
public class Visit
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Reason { get; set; }
    public Animal Animal { get; set; }
}