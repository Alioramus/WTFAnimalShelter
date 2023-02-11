using System.Text.RegularExpressions;
using NLog;

namespace AnimalShelter;

public interface IUsernameService
{
    (bool, Result) IsCorrectLength(string username);
    (bool, Result) IsCorrectCharacters(string username);
}

public partial class UsernameService : IUsernameService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public (bool, Result) IsCorrectLength(string username) =>
        username.Length switch
        {
            < 5 => (false, Result.TooShort),
            > 20 => (false, Result.TooLong),
            _ => (true, Result.Correct)
        };

    public (bool, Result) IsCorrectCharacters(string username)
    {
        var regex = UsernameMatchRegex();
        var matched = regex.IsMatch(username);
        if (!matched)
            Logger.Warn("Username doesn't match regex.");
        return matched ? (true, Result.Correct) : (false, Result.InvalidCharacters);
    }

    // start with a letter, allow letter or number
    [GeneratedRegex("^[a-zA-Z][a-zA-Z0-9]+$")]
    private static partial Regex UsernameMatchRegex();
}