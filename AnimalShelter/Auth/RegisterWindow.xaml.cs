using System.Windows;
using System.Windows.Controls;
using Autofac;
using NLog;

namespace AnimalShelter;

public partial class RegisterWindow
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IAuthService _authService;
    private readonly IUsernameService _usernameService;
    private readonly IPasswordService _passwordService;


    public RegisterWindow()
    {
        InitializeComponent();
        using var scope = App.AppContainer.BeginLifetimeScope();
        _authService = scope.Resolve<IAuthService>();
        _usernameService = scope.Resolve<IUsernameService>();
        _passwordService = scope.Resolve<IPasswordService>();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        var role = RoleCombo.Text;

        if (!IsCorrectUserName(username) && !IsCorrectPassword(password))
        {
            return;
        }


        // Pobierz wybraną rolę z ComboBox
        var selectedRole = role switch
        {
            "Veterinarian" => UserRole.Veterinarian,
            "Administrator" => UserRole.Administrator,
            _ => UserRole.Keeper
        };

        Logger.Info($"Registering user {username} with role {selectedRole}.");

        // Zarejestruj użytkownika
        var (isRegistered, result) = _authService.TryRegister(username, password, selectedRole);
        if (isRegistered)
        {
            MessageBox.Show("Rejestracja powiodła się!", "Informacja", MessageBoxButton.OK,
                MessageBoxImage.Information);
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            Logger.Info("Registration successful.");
            Close();
        }
        else if (result == Result.UsernameDuplicated)
        {
            MessageBox.Show("Nazwa użytkownika jest już zajęta.", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username is already taken.");
        }
        else
        {
            MessageBox.Show("Wystąpił błąd podczas rejestracji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            Logger.Info("Registration failed.");
        }
    }

    private bool IsCorrectUserName(string username)
    {
        Logger.Info("Checking username...");
        var (_, lengthResult) = _usernameService.IsCorrectLength(username);
        var (_, charactersResult) = _usernameService.IsCorrectCharacters(username);

        if (lengthResult == Result.TooShort)
        {
            MessageBox.Show("Nazwa użytkownika jest za krótka (<5 znaków).", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username is too short.");
            return false;
        }

        if (lengthResult == Result.TooLong)
        {
            MessageBox.Show("Nazwa użytkownika jest za długa (>20 znaków).", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username is too long.");
            return false;
        }


        if (charactersResult == Result.InvalidCharacters)
        {
            MessageBox.Show("Nazwa użytkownika zawiera niedozwolone znaki.", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username contains invalid characters.");
            return false;
        }

        return true;
    }


    private bool IsCorrectPassword(string password)
    {
        Logger.Info("Checking password...");

        var (_, lengthResult) = _passwordService.IsCorrectLength(password);
        var (_, charactersResult) = _passwordService.IsCorrectCharacters(password);


        if (lengthResult == Result.TooShort)
        {
            MessageBox.Show("Nazwa użytkownika jest za krótka (<5 znaków).", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username is too short.");
            return false;
        }

        if (lengthResult == Result.TooLong)
        {
            MessageBox.Show("Nazwa użytkownika jest za długa (>20 znaków).", "Błąd", MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            Logger.Warn("Username is too long.");
            return false;
        }


        if (charactersResult == Result.InvalidCharacters)
        {
            MessageBox.Show(
                "Niepoprawne hasło. Wymagane: conajmniej jedna wielka litera, jedna mała litera i jedna cyfra.",
                "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            Logger.Warn("Incorrect password.");
            return false;
        }

        return true;
    }


    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Logger.Info("Opening login window.");
        new LoginWindow().Show();
        Close();
    }

    private void UsernameText_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        RegisterButton.IsEnabled = UsernameText.Text.Length > 0 && PasswordText.Password.Length > 0;
    }

    private void PasswordText_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        RegisterButton.IsEnabled = UsernameText.Text.Length > 0 && PasswordText.Password.Length > 0;
    }
}