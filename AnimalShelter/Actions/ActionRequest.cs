using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnimalShelter.Animals
{
    public class ActionRequest
    {
        [Key]
        public int Id {get; set;}
        public string Name { get; set; }
        public ShelterActionType Type { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
    }
}