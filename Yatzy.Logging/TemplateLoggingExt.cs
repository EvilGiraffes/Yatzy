using Serilog;
using Serilog.Events;

namespace Yatzy.Logging;
/// <summary>
/// Extentions for <see cref="ILogger"/> where it ads the ability to use <see cref="LogTemplate"/>.
/// </summary>
public static class TemplateLoggingExt
{
    /// <summary>
    /// <inheritdoc cref="ILogger.Write(LogEventLevel, Exception, string, object[])" path="/summary"/>
    /// </summary>
    /// <param name="logger">The logger to write with.</param>
    /// <param name="level"><inheritdoc cref="ILogger.Write(LogEventLevel, Exception, string, object[])" path="/param[@name='level']"/></param>
    /// <param name="exception"><inheritdoc cref="ILogger.Write(LogEventLevel, Exception, string, object[])" path="/param[@name='exception']"/></param>
    /// <param name="template">The template to write the event according to.</param>
    public static void Write(this ILogger logger, LogEventLevel level, Exception? exception, LogTemplate template)
        => logger.Write(level, exception, template.Template, template.Args);
    /// <summary>
    /// <inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/param[@name='logger']"/></param>
    /// <param name="level"><inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/param[@name='level']"/></param>
    /// <param name="template"><inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/param[@name='template']"/></param>
    public static void Write(this ILogger logger, LogEventLevel level, LogTemplate template)
        => Write(logger, level, null, template);
    /// <summary>
    /// <inheritdoc cref="ILogger.Error(string, object[])" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/param[@name='logger']"/></param>
    /// <param name="template"><inheritdoc cref="Write(ILogger, LogEventLevel, Exception, LogTemplate)" path="/param[@name='template']"/></param>
    public static void Error(this ILogger logger, LogTemplate template)
        => Write(logger, LogEventLevel.Error, template);
}
