using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AnimalShelter;

public class AdminModel : INotifyPropertyChanged
{
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
}