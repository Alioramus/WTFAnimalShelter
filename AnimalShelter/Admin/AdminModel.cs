namespace AnimalShelter;

public class AdminModel
{
    private readonly ShelterContext _context;
    public AdminModel(ShelterContext context)
    {
        _context = context;
    }
}