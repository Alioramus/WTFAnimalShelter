using AnimalShelter;

namespace AnimalShelterTests.Auth;

    public class UsernameServiceTests
    {
        private readonly IUsernameService _usernameService;

        public UsernameServiceTests()
        {
            _usernameService = new UsernameService();
        }

        [Fact]
        public void IsCorrectLength_GivenUsernameWithLengthLessThan5_ReturnsFalseTooShort()
        {
            // Arrange
            var username = "a";

            // Act
            var (isCorrect, result) = _usernameService.IsCorrectLength(username);

            // Assert
            Assert.False(isCorrect);
            Assert.Equal(Result.TooShort, result);
        }

        [Fact]
        public void IsCorrectLength_GivenUsernameWithLengthMoreThan20_ReturnsFalseTooLong()
        {
            // Arrange
            var username = "abcdefghijklmnopqrstuvwxyz";

            // Act
            var (isCorrect, result) = _usernameService.IsCorrectLength(username);

            // Assert
            Assert.False(isCorrect);
            Assert.Equal(Result.TooLong, result);
        }

        [Fact]
        public void IsCorrectLength_GivenUsernameWithCorrectLength_ReturnsTrueCorrect()
        {
            // Arrange
            var username = "abcdef";

            // Act
            var (isCorrect, result) = _usernameService.IsCorrectLength(username);

            // Assert
            Assert.True(isCorrect);
            Assert.Equal(Result.Correct, result);
        }

        [Fact]
        public void IsCorrectCharacters_GivenUsernameWithInvalidCharacters_ReturnsFalseInvalidCharacters()
        {
            // Arrange
            var username = "abc#";

            // Act
            var (isCorrect, result) = _usernameService.IsCorrectCharacters(username);

            // Assert
            Assert.False(isCorrect);
            Assert.Equal(Result.InvalidCharacters, result);
        }

        [Fact]
        public void IsCorrectCharacters_GivenUsernameWithCorrectCharacters_ReturnsTrueCorrect()
        {
            // Arrange
            var username = "abc1";

            // Act
            var (isCorrect, result) = _usernameService.IsCorrectCharacters(username);

            // Assert
            Assert.True(isCorrect);
            Assert.Equal(Result.Correct, result);
        }
    }