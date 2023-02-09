using System.Linq;

namespace AnimalShelter;

public interface IAuthService
{
    public bool Login(string username, string password);
    public bool Register(string username, string password, UserRole role);
}
public class AuthService: IAuthService
{
    private readonly ShelterContext _context;
    public AuthService(ShelterContext context)
    {
        _context = context;
    }
    
    public bool Login(string username, string password)
    {
        return _context.Users.Any(user => user.Username == username && user.Password == password);
    }
    
    public bool Register(string username, string password, UserRole role)
    {
        if (_context.Users.Any(u => u.Username == username))
        {
            return false;
        }

        var user = new User
        {
            Username = username,
            Password = password,
            Role = role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return true;
    }
}
