using System.Linq;

namespace AnimalShelter;

// TODO: use DI
public class AuthService
{
    public bool Login(string username, string password)
    {
        using var dataContext = new ShelterContext();
        return dataContext.Users.Any(user => user.Username == username && user.Password == password);
    }
    
    public bool Register(string username, string password, UserRole role)
    {
        using var context = new ShelterContext();
        if (context.Users.Any(u => u.Username == username))
        {
            return false;
        }

        var user = new User
        {
            Username = username,
            Password = password,
            Role = role
        };

        context.Users.Add(user);
        context.SaveChanges();

        return true;
    }
}
