using Serilog;

namespace Yatzy.Errors;
/// <summary>
/// Reperesents an exception where the dice face is not within the specified range.
/// </summary>
public class DiceFaceOutOfRange : Exception
{
    static string GuardTemplate
        => "The value {Value} is out of range defined as {Min}-{Max}. Exception thrown with message {Message}";
    public DiceFaceOutOfRange()
    {
    }

    public DiceFaceOutOfRange(string? message) : base(message)
    {
    }

    public DiceFaceOutOfRange(string? message, Exception? inner) : base(message, inner)
    {
    }
    /// <summary>
    /// Helper function to guard against a dice face being out of range.
    /// </summary>
    /// <param name="logger">The logger used throughout the application.</param>
    /// <param name="value">The current value.</param>
    /// <param name="range">The range it should be within.</param>
    /// <param name="tooSmallMessage">A message when it is deemed below minimum.</param>
    /// <param name="tooLargeMessage">A message when it is deemed above maximum.</param>
    /// <exception cref="DiceFaceOutOfRange">Thrown if the value is deemed out of range.</exception>
    public static void Guard(ILogger logger, int value, DiceRange range, string? tooSmallMessage, string? tooLargeMessage)
    {
        if (value < range.MinimumFace)
        {
            logger.Error(GuardTemplate, value, range.MinimumFace, range.MaximumFace, tooSmallMessage);
            throw new DiceFaceOutOfRange(tooSmallMessage);
        }
        if (value > range.MaximumFace)
        {
            logger.Error(GuardTemplate, value, range.MinimumFace, range.MaximumFace, tooLargeMessage);
            throw new DiceFaceOutOfRange(tooLargeMessage);
        }
    }
    /// <summary>
    /// <inheritdoc cref="Guard(ILogger, int, DiceRange, string?, string?)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="Guard(ILogger, int, DiceRange, string?, string?)" path="/param[@name='logger']"/></param>
    /// <param name="value"><inheritdoc cref="Guard(ILogger, int, DiceRange, string?, string?)" path="/param[@name='value']"/></param>
    /// <param name="range"><inheritdoc cref="Guard(ILogger, int, DiceRange, string?, string?)" path="/param[@name='range']"/></param>
    /// <param name="message">A message when it is out of range.</param>
    /// <exception cref="DiceFaceOutOfRange"><inheritdoc cref="Guard(int, int, int, string?, string?)" path="/exception"/></exception>
    public static void Guard(ILogger logger, int value, DiceRange range, string? message = null)
        => Guard(logger, value, range, message, message);
}
