using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class Admin
{
    [Key] public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public User User { get; set; }
}