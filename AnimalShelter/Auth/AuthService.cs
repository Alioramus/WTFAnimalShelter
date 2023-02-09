using System.Linq;
using NLog;

namespace AnimalShelter;

public interface IAuthService
{
    public bool TryLogin(string username, string password);
    public (bool, Result) TryRegister(string username, string password, UserRole role);
}

public class AuthService: IAuthService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly ShelterContext _context;

    public AuthService(ShelterContext context)
    {
        _context = context;
    }
    
    public bool TryLogin(string username, string password)
    {
        return _context.Users.Any(user => user.Username == username && user.Password == password);
    }
    
    public (bool, Result) TryRegister(string username, string password, UserRole role)
    {
        if (_context.Users.Any(u => u.Username == username))
        {
            return (false, Result.UsernameDuplicated);
        }

        var user = new User
        {
            Username = username,
            Password = password,
            Role = role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return (true, Result.Correct);
    }
}
