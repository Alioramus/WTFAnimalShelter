using System.Linq;
using System.Windows;

namespace AnimalShelter;

/// <summary>
/// Logika interakcji dla klasy LoginWindow.xaml
/// </summary>
public partial class LoginWindow
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        using var dataContext = new ShelterContext();
        var correctCredentials = dataContext.Users.Any(user => user.Name == username && user.Password == password);
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