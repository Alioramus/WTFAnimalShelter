using System.Windows;

namespace AnimalShelter;

/// <summary>
/// Logika interakcji dla klasy LoginWindow.xaml
/// </summary>
public partial class LoginWindow
{
    private readonly Auth _auth;

    public LoginWindow()
    {
        InitializeComponent();
        _auth = new Auth();

    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        if (_auth.Login(username, password))
        {
            new MainWindow().Show();
            Close();
        } else
        {
            MessageBox.Show("Invalid credentials.");
        }
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        var registerWindow = new RegisterWindow();
        registerWindow.Show();
        Close();
    }
}