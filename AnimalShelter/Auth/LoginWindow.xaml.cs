using System.Windows;
using Autofac;

namespace AnimalShelter;

/// <summary>
/// Logika interakcji dla klasy LoginWindow.xaml
/// </summary>
public partial class LoginWindow
{
    private readonly IAuthService _authService;

    public LoginWindow()
    {
        InitializeComponent();
        using var scope = App.AppContainer.BeginLifetimeScope();
        _authService = scope.Resolve<IAuthService>();
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