using Serilog;

using Yatzy.Logging.ExceptionLoggingHandlers;


namespace Yatzy.Logging;
// TESTME: Need to test the different implementations of this.
/// <summary>
/// Represents extention methods to handle exception logging.
/// </summary>
public static class LogException
{
    static IExceptionLoggingHandler<Exception> AnyExceptionHandler
        => LoggingExtentionConfiguration.Options.Exception.AnyExceptionHandler;
    /// <summary>
    /// Will log exception information.
    /// </summary>
    /// <typeparam name="TException">The type of exception to log, will use a logger for any exception if not provided.</typeparam>
    /// <param name="logger"></param>
    /// <param name="exception"></param>
    /// <param name="loggingHandler"></param>
    public static void Exception<TException>(this ILogger logger, TException exception, IExceptionLoggingHandler<TException>? loggingHandler = null)
        where TException : Exception
    {
        if (loggingHandler is null)
        {
            AnyExceptionHandler.Log(logger, exception);
            return;
        }
        loggingHandler.Log(logger, exception);
    }
}
