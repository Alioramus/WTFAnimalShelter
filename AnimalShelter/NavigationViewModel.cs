using System;
using System.ComponentModel;
using System.Windows.Input;
using AnimalShelter.Animals;
using AnimalShelter.Actions;

namespace AnimalShelter;

public class BaseCommand : ICommand
{
    private readonly Action<object> _method;
    public event EventHandler CanExecuteChanged;

    public BaseCommand(Action<object> method)
    {
        _method = method;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _method.Invoke(parameter);
    }
}

class NavigationViewModel : INotifyPropertyChanged
{
    public ICommand EmpCommand { get; set; }
    public ICommand AnimalsListCommand { get; set; }
    public ICommand ActionsListCommand { get; set; }
    public ICommand VeterinaryCommand { get; set; }

    private object _selectedViewModel;
    private readonly ShelterContext _context;

    public object SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            _selectedViewModel = value;
            OnPropertyChanged("SelectedViewModel");
        }
    }

    public NavigationViewModel(ShelterContext context)
    {
        this._context = context;
        EmpCommand = new BaseCommand(OpenEmp);
        AnimalsListCommand = new BaseCommand(OpenAnimalsList);
        ActionsListCommand = new BaseCommand(OpenActionsList);
        VeterinaryCommand = new BaseCommand(OpenVeterinary);
    }

    private void OpenEmp(object obj)
    {
        SelectedViewModel = new AnimalDetailsModel();
    }

    private void OpenAnimalsList(object obj)
    {
        SelectedViewModel = new AnimalsModel(_context);
    }

    private void OpenActionsList(object obj)
    {
        SelectedViewModel = new ActionsModel(_context);
    }

    private void OpenVeterinary(object obj)
    {
        SelectedViewModel = new VeterinaryModel(_context);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}