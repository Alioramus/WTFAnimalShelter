using System.ComponentModel.DataAnnotations;

namespace AnimalShelter;

public class ShelterAction
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ShelterActionType Type { get; set; }
    public ShelterActionStatus Status { get; set; }
    public string Description { get; set; }
    public User Assignee { get; set; }
    public Animal Animal { get; set; }
        
}