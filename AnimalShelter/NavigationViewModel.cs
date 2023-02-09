using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AnimalShelter.Animals;

namespace AnimalShelter
{
    public class BaseCommand : ICommand
    {
        private Action<object> _method;
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

        private object selectedViewModel;
        private ShelterContext context;

        public object SelectedViewModel

        {

            get { return selectedViewModel; }

            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }

        }



        public NavigationViewModel(ShelterContext context)

        {
            this.context = context;
            EmpCommand = new BaseCommand(OpenEmp);

            AnimalsListCommand = new BaseCommand(OpenAnimalsList);

        }

        private void OpenEmp(object obj)

        {

            SelectedViewModel = new AnimalDetailsModel();

        }

        private void OpenAnimalsList(object obj)

        {

            SelectedViewModel = new AnimalsListModel(context);

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
}
