using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NLog;

namespace AnimalShelter;

public class AdminModel : INotifyPropertyChanged
{
    private readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly ShelterContext _context;

    private List<User> _users;

    public List<User> Users
    {
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged("Users");
        }
    }

    private User _selectedUser;

    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged("SelectedUser");
        }
    }

    public AdminModel(ShelterContext context)
    {
        _context = context;
        Users = _context.Users.Where(user => user != App.CurrentUser).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public void DeleteUser()
    {
        var admin = _context.Admins.FirstOrDefault(admin => admin.User == SelectedUser);
        if (admin != null)
            _context.Admins.Remove(admin);
        var keeper = _context.Keepers.FirstOrDefault(keeper => keeper.User == SelectedUser);
        if (keeper != null)
            _context.Keepers.Remove(keeper);
        var vet = _context.Vets.FirstOrDefault(vet => vet.User == SelectedUser);
        if (vet != null)
            _context.Vets.Remove(vet);
        _context.Users.Remove(SelectedUser);
        _context.SaveChanges();
        Users = _context.Users.Where(user => user != App.CurrentUser).ToList();
    }

    public void SaveUser(User selectedUser)
    {
        _context.Users.Update(selectedUser);
        _context.SaveChanges();
        Users = _context.Users.Where(user => user != App.CurrentUser).ToList();
    }
}