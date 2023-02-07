using System.Windows;

namespace AnimalShelter;

public partial class RegisterWindow
{
    private Auth _auth;
    public RegisterWindow()
    {
        InitializeComponent();
        _auth = new Auth();
    }
    
    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameText.Text;
        var password = PasswordText.Password;
        var role = RoleCombo.Text;

        // Pobierz wybraną rolę z ComboBox
        var selectedRole = role switch
        {
            "Veterinarian" => UserRole.Veterinarian,
            "Administrator" => UserRole.Administrator,
            _ => UserRole.Keeper
        };

        // Zarejestruj użytkownika
        var success = _auth.Register(username, password, selectedRole);
        if (success)
        {
            MessageBox.Show("Rejestracja powiodła się!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            new MainWindow().Show();
            Close();
        }
        else
        {
            MessageBox.Show("Wystąpił błąd podczas rejestracji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        new LoginWindow().Show();
        Close();
    }
}