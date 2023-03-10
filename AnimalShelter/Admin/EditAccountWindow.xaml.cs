using System.Windows;

namespace AnimalShelter;

public partial class EditAccountWindow
{
    public User SelectedUser { get; set; }

    public EditAccountWindow(User selectedUser)
    {
        InitializeComponent();
        SelectedUser = selectedUser;
        Username.Text = SelectedUser.Username;
        Password.Password = SelectedUser.Password;
        RoleCombo.Text = SelectedUser.Role.ToString();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        var adminModel = DataContext as AdminModel;
        SelectedUser.Username = Username.Text;
        SelectedUser.Password = Password.Password;
        UserRole role;
        UserRole.TryParse(RoleCombo.Text, out role);
        SelectedUser.Role = role;
        adminModel.SaveUser(SelectedUser);
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}