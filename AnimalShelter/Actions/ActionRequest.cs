using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnimalShelter.Animals
{
    public class ActionRequest
    {
        public string Name { get; set; }
        public ShelterActionType Type { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
    }
}