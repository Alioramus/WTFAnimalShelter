using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class Keeper
{
    [Key]
    public int KeeperId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime EmploymentDate { get; set; }
    public Roles SelectedRole { get; set; } = Roles.Role1;

    public override string ToString() => $"{FirstName} {LastName}";

}

public enum Roles
{
    Role1,
    Role2
}