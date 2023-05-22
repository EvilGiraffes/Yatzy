using Yatzy.Logging.ExceptionLoggingHandlers;

namespace Yatzy.Logging.Configuration;
/// <summary>
/// Represents options for <see cref="LogException"/> extentions.
/// </summary>
public sealed class ExceptionOptions
{
    /// <summary>
    /// This is the <see cref="IExceptionLoggingHandler{TException}"/> that will handle the logging if no custom handler is provided. It must work on any exception.
    /// </summary>
    public IExceptionLoggingHandler<Exception> AnyExceptionHandler { get; set; } = ExceptionLoggingHandlers.AnyExceptionHandler.Create();
    internal ExceptionOptions()
    {
    }
}
