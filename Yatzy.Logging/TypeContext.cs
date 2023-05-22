using Serilog;

namespace Yatzy.Logging;
/// <summary>
/// Extention methods which handles type context.
/// </summary>
/// <remarks>The internal representation by default is "Type".</remarks>
public static class TypeContext
{
    /// <summary>
    /// Gives the logger a type context. The context is represented as "Type".
    /// </summary>
    /// <param name="logger">The logger to give context to.</param>
    /// <param name="type">The type to add the context.</param>
    /// <returns>An enriched logger with the type.</returns>
    public static ILogger ForType(this ILogger logger, Type type)
        => logger.ForContext("Type", type.Name);
    /// <summary>
    /// <inheritdoc cref="ForType(ILogger, Type)" path="/summary"/>
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="ForType(ILogger, Type)" path="/param[@name='type']"/></typeparam>
    /// <param name="logger"><inheritdoc cref="ForType(ILogger, Type)" path="/param[@name='logger']"/></param>
    /// <returns><inheritdoc cref="ForType(ILogger, Type)" path="/returns"/></returns>
    public static ILogger ForType<T>(this ILogger logger)
        => logger.ForType(typeof(T));
}
