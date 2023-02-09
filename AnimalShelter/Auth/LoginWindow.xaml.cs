using System.Windows;
using System.Windows.Controls;
using Autofac;
using NLog;

namespace AnimalShelter;

/// <summary>
/// Logika interakcji dla klasy LoginWindow.xaml
/// </summary>
public partial class LoginWindow
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IAuthService _authService;

    public LoginWindow()
    {
        InitializeComponent();
        using var scope = App.AppContainer.BeginLifetimeScope();
        _authService = scope.Resolve<IAuthService>();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        Logger.Info("Clicked login button.");
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        if (_authService.TryLogin(username, password))
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

    private void UsernameText_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        LoginButton.IsEnabled = UsernameText.Text.Length > 0 && PasswordText.Password.Length > 0;
    }

    private void PasswordText_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        LoginButton.IsEnabled = UsernameText.Text.Length > 0 && PasswordText.Password.Length > 0;
    }
}