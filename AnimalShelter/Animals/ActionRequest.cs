namespace AnimalShelter.Animals
{
    public class ActionRequest
    {
        public string Name { get; set; }
        public ShelterActionType Type { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
    }
}