using System.Windows;

namespace AnimalShelter;

/// <summary>
/// Logika interakcji dla klasy LoginWindow.xaml
/// </summary>
public partial class LoginWindow
{
    private readonly AuthService _authService;

    public LoginWindow()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        if (_authService.Login(username, password))
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
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