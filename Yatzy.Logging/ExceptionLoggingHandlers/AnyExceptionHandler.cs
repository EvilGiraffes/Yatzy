using Serilog;
using Serilog.Events;

using Yatzy.Logging.Errors;

namespace Yatzy.Logging.ExceptionLoggingHandlers;
// TESTME: Needs to test logging functionality.
/// <summary>
/// Will log any exception as if it was just an <see cref="Exception"/>.
/// </summary>
public sealed class AnyExceptionHandler : IExceptionLoggingHandler<Exception>
{
    readonly Action<ILogger, string> loggingHandler;
    AnyExceptionHandler(Action<ILogger, string> loggingHandler)
    {
        this.loggingHandler = loggingHandler;
    }
    /// <inheritdoc/>
    public void Log(ILogger logger, Exception exception)
    {
        string?[] messages =
        {
            exception.Message,
            exception.StackTrace
        };
        foreach (string? message in messages)
            LogIfNotNullOrEmpty(logger, message);
    }
    void LogIfNotNullOrEmpty(ILogger logger, string? message)
    {
        if (string.IsNullOrEmpty(message))
            return;
        loggingHandler(logger, message);
    }
    /// <summary>
    /// Creates a new instance of <see cref="AnyExceptionHandler"/> which will log in the given level.
    /// </summary>
    /// <param name="level">The level to log in, cannot be less than <see cref="LogEventLevel.Warning"/>.</param>
    /// <returns>A new instance of <see cref="AnyExceptionHandler"/>.</returns>
    /// <exception cref="ArgumentException">TODO: Change according to new exception.</exception>
    public static AnyExceptionHandler Create(LogEventLevel level = LogEventLevel.Error)
    {
        if (level < LogEventLevel.Warning)
            // TODO: Change into a better exception.
            throw new ArgumentException("Level is too low.");
        return new(GetLoggingFunction(level));
    }
    static Action<ILogger, string> GetLoggingFunction(LogEventLevel level)
        => level switch
        {
            LogEventLevel.Warning => (logger, message) => logger.Warning(message),
            LogEventLevel.Error => (logger, message) => logger.Error(message),
            LogEventLevel.Fatal => (logger, message) => logger.Fatal(message),
            _ => throw new UnReachableException()
        };
}
