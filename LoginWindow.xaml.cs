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
using System.Windows.Shapes;

namespace WTFAnimalShelter
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var Username = UsernameText.Text;
            var Password = PasswordText.Password;
            using(ShelterContext dataContext = new ShelterContext())
            {
                bool correctCredentials = dataContext.Users.Any(user => user.Name == Username && user.Password == Password);
                if (correctCredentials)
                {
                    new MainWindow().Show();
                    Close();
                } else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }

        }
    }
}
