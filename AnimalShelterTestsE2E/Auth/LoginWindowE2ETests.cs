using System.Windows;
using AnimalShelter;
using Moq;

namespace AnimalShelterE2E.Auth;

public class LoginWindowE2ETests: E2EFixture
{
    [UIFact]
    public void Login_WithValidCredentials_ShouldOpenMainWindow()
    {
        // Arrange
        var authServiceMock = new Mock<IAuthService>();
        authServiceMock.Setup(x => x.TryLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        var loginWindow = new LoginWindow(authServiceMock.Object);
        
        // Act
        loginWindow.UsernameText.Text = "username";
        loginWindow.PasswordText.Password = "password";
        loginWindow.Login_Click(null, null);

        // Assert
        Assert.True(Application.Current.MainWindow!.IsVisible);
    }

}