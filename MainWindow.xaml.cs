using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WTFAnimalShelter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {

        public List<Animal> Animals { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            using(ShelterContext context = new ShelterContext())
            {
                this.Animals = context.Animals.ToList();
            }
            this.DataContext = this;
        }
    }
}
