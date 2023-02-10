using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class Vet
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public User User { get; set; }
}