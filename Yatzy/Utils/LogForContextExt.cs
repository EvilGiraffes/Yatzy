using Serilog;

namespace Yatzy.Utils;
/// <summary>
/// Extention methods for logging.
/// </summary>
public static class LogForContextExt
{
    /// <summary>
    /// Gives the logger a type context. The context is represented as "Type".
    /// </summary>
    /// <typeparam name="T">The type to add as the context.</typeparam>
    /// <param name="logger">The logger to give context to.</param>
    /// <returns>An enriched logger with the type.</returns>
    public static ILogger ForType<T>(this ILogger logger)
        => logger.ForContext("Type", typeof(T).Name);
}
