using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}

/// <summary>
/// The role of the user
/// </summary>
public enum Role
{
    Keeper,
    Veterinarian,
    Administrator
}
