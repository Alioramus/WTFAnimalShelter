using AnimalShelter;

namespace AnimalShelterTests.Auth
{
    public class PasswordServiceTests
    {
        private readonly IPasswordService _passwordService = new PasswordService();

        [Fact]
        public void IsCorrectLength_PasswordTooShort_ReturnsFalseAndTooShortReason()
        {
            const string password = "abc";

            var (isCorrectLength, result) = _passwordService.IsCorrectLength(password);

            Assert.False(isCorrectLength);
            Assert.Equal(Result.TooShort, result);
        }

        [Fact]
        public void IsCorrectLength_PasswordCorrectLength_ReturnsTrueAndCorrectReason()
        {
            const string password = "abcdefghijklmn";

            var (isCorrectLength, result) = _passwordService.IsCorrectLength(password);

            Assert.True(isCorrectLength);
            Assert.Equal(Result.Correct, result);
        }

        [Fact]
        public void IsCorrectLength_PasswordTooLong_ReturnsFalseAndTooLongReason()
        {
            const string password = "abcdefghijklmnopqrstuvwxyz12345";

            var (isCorrectLength, result) = _passwordService.IsCorrectLength(password);

            Assert.False(isCorrectLength);
            Assert.Equal(Result.TooLong, result);
        }

        [Fact]
        public void IsCorrectCharacters_PasswordDoesNotMatchRegex_ReturnsFalseAndInvalidCharactersReason()
        {
            const string password = "abcdefg";

            var (isCorrectCharacters, result) = _passwordService.IsCorrectCharacters(password);

            Assert.False(isCorrectCharacters);
            Assert.Equal(Result.InvalidCharacters, result);
        }

        [Fact]
        public void IsCorrectCharacters_PasswordMatchesRegex_ReturnsTrueAndCorrectReason()
        {
            const string password = "Abcdefg1";

            var (isCorrectCharacters, result) = _passwordService.IsCorrectCharacters(password);

            Assert.True(isCorrectCharacters);
            Assert.Equal(Result.Correct, result);
        }
    }
}