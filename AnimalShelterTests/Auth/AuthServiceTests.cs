using AnimalShelter;
using Autofac;

namespace AnimalShelterTests.Auth;

public class AuthServiceTests : InMemoryDbTests
{
    [Fact]
    public void TryLogin_ValidCredentials_ReturnsTrue()
    {
        // Arrange
        const string username = "valid_username";
        const string password = "valid_password";

        var context = App.AppContainer.Resolve<ShelterContext>();
        var user = new User { Username = username, Password = password, Role = UserRole.Keeper };
        context.Users.Add(user);
        context.Keepers.Add(new Keeper { User = user });
        context.SaveChanges();
        var authService = new AuthService(context);

        // Act
        var result = authService.TryLogin(username, password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TryLogin_InvalidCredentials_ReturnsFalse()
    {
        // Arrange
        const string username = "valid_username";
        const string password = "valid_password";

        var context = App.AppContainer.Resolve<ShelterContext>();
        context.Users.Add(new User { Username = username, Password = password, Role = UserRole.Keeper });
        context.SaveChanges();
        var authService = new AuthService(context);

        // Act
        var result = authService.TryLogin("invalid_username", "invalid_password");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TryRegister_UniqueUsername_ReturnsTrueAndCorrectResult()
    {
        // Arrange
        const string username = "valid_username";
        const string password = "valid_password";
        const UserRole role = UserRole.Keeper;
        var context = App.AppContainer.Resolve<ShelterContext>();
        var authService = new AuthService(context);

        // Act
        var (success, result) = authService.TryRegister(username, password, role);

        // Assert
        Assert.True(success);
        Assert.Equal(Result.Correct, result);
    }
}