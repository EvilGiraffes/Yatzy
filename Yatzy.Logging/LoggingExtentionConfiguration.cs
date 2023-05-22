using Yatzy.Logging.Configuration;

namespace Yatzy.Logging;
/// <summary>
/// Configures all the options for this logging package.
/// </summary>
public static class LoggingExtentionConfiguration
{
    internal static LoggingExtentionOptions Options { get; } = new LoggingExtentionOptions();
    /// <summary>
    /// Provides a way to setup the package.
    /// </summary>
    /// <param name="setup">The function to handle all of the setup.</param>
    public static void Setup(Action<LoggingExtentionOptions> setup)
        => setup(Options);
}
