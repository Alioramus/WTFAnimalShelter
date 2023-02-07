using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class User
{
    [Key] public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

/// <summary>
/// The role of the user
/// </summary>
public enum UserRole
{
    Keeper,
    Veterinarian,
    Administrator
}