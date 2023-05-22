namespace Yatzy.Logging.Configuration;
// TODO: Setup.
/// <summary>
/// Represents all of the options used by this package.
/// </summary>
public sealed class LoggingExtentionOptions
{
    /// <summary>
    /// Gets the options to configure <see cref="LogException"/>.
    /// </summary>
    public ExceptionOptions Exception { get; } = new();
    internal LoggingExtentionOptions()
    {
    }
}
