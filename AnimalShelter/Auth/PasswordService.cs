using System.Text.RegularExpressions;
using NLog;

namespace AnimalShelter;

public interface IPasswordService
{
    (bool, Result) IsCorrectLength(string password);
    (bool, Result) IsCorrectCharacters(string password);
}

public partial class PasswordService : IPasswordService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public (bool, Result) IsCorrectLength(string password) =>
        password.Length switch
        {
            < 5 => (false, TOO_SHORT: Result.TooShort),
            > 20 => (false, TOO_LONG: Result.TooLong),
            _ => (true, CORRECT: Result.Correct)
        };

    public (bool, Result) IsCorrectCharacters(string password)
    {
        var regex = PasswordMatchRegex();
        var matched = regex.IsMatch(password);
        if (matched)
            Logger.Warn("Password doesn't match regex.");
        return matched ? (true, CORRECT: Result.Correct) : (false, INVALID_CHARACTERS: Result.InvalidCharacters);
        ;
    }


    [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,20}$")]
    private static partial Regex PasswordMatchRegex();
}