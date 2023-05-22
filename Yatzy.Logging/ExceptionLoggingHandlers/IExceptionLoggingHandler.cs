using Serilog;

namespace Yatzy.Logging.ExceptionLoggingHandlers;
/// <summary>
/// Represents a handler which will log the exception.
/// </summary>
/// <typeparam name="TException">The exception this handler can handle.</typeparam>
public interface IExceptionLoggingHandler<TException>
{
    /// <summary>
    /// Will log the exception according to its own instructions.
    /// </summary>
    /// <param name="logger">The logger which will be used to log with.</param>
    /// <param name="exception">The exception in question.</param>
    void Log(ILogger logger, TException exception);
}
