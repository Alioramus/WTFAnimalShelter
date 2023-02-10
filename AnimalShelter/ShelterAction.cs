using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter
{
    public class ShelterAction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ShelterActionType Type { get; set; }
        public ShelterActionStatus Status { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public int AssigneeId { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        
    }
}