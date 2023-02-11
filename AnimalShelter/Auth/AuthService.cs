using System;
using System.Linq;
using NLog;

namespace AnimalShelter;

public interface IAuthService
{
    public bool TryLogin(string username, string password);
    public (bool, Result) TryRegister(string username, string password, UserRole role);
}

public class AuthService : IAuthService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly ShelterContext _context;

    public AuthService(ShelterContext context)
    {
        _context = context;
    }

    public bool TryLogin(string username, string password)
    {
        var userLogged = _context.Users.Any(user => user.Username == username && user.Password == password);
        if (!userLogged) return userLogged;

        Logger.Info($"User logged: {username}");
        var currentUser = App.CurrentUser = _context.Users.First(user => user.Username == username);
        switch (currentUser.Role)
        {
            case UserRole.Veterinarian:
                App.CurrentVet = _context.Vets.First(vet => vet.User == currentUser);
                break;
            case UserRole.Keeper:
                App.CurrentKeeper = _context.Keepers.First(keeper => keeper.User == currentUser);
                break;
            case UserRole.Administrator:
                App.CurrentAdmin = _context.Admins.First(admin => admin.User == currentUser);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentUser.Role), currentUser.Role, null);
        }
        
        return userLogged;
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

        switch (role)
        {
            case UserRole.Veterinarian:
                var vet = new Vet
                {
                    User = user
                };
                _context.Vets.Add(vet);
                App.CurrentVet = vet;
                break;
            case UserRole.Keeper:
                var keeper = new Keeper
                {
                    User = user
                };
                _context.Keepers.Add(keeper);
                App.CurrentKeeper = keeper;
                break;
            case UserRole.Administrator:
                var admin = new Admin
                {
                    User = user
                };
                _context.Admins.Add(admin);
                App.CurrentAdmin = admin;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(role), role, null);
        }

        _context.Users.Add(user);
        _context.SaveChanges();
        App.CurrentUser = user;
        return (true, Result.Correct);
    }
}