using Serilog;

using Yatzy.Logging;

namespace Yatzy.Scoreboards.Renderers;
/// <summary>
/// Represents a renderer who will render it as a simple line with the provided seperators.
/// </summary>
public sealed class StringSeperated : IRenderer
{
    /// <summary>
    /// The default seperator for each pair.
    /// </summary>
    public readonly static string DefaultSeperator = Environment.NewLine;
    /// <summary>
    /// The default seperator for the key and value in the scoreboard.
    /// </summary>
    public const string DefaultKeyValueSeperator = ", ";
    readonly string keyValueSeperator;
    readonly string seperator;
    readonly ILogger logger;
    /// <summary>
    /// Constructs a new instance of the renderer.
    /// </summary>
    /// <param name="logger">The current logger instance being used throughout the application.</param>
    /// <param name="seperator"> 
    /// <para>
    /// Seperator to be used between each key value pair.
    /// </para>
    /// <para>
    /// If none is provided it will use <see cref="DefaultSeperator"/> represented as <see cref="Environment.NewLine"/>.
    /// </para>
    /// </param>
    /// <param name="keyValueSeperator">
    /// <para>
    /// Seperator that is used between the key and value pair.
    /// </para>
    /// <para>
    /// If none is provided it will use <see cref="DefaultKeyValueSeperator"/> represented as ", ".
    /// </para>
    /// </param>
    public StringSeperated(ILogger logger, string? seperator = null, string? keyValueSeperator = null)
    {
        this.logger = logger.ForType<StringSeperated>();
        seperator ??= DefaultSeperator;
        this.seperator = seperator;
        keyValueSeperator ??= DefaultKeyValueSeperator;
        this.keyValueSeperator = keyValueSeperator;
    }
    // TODO: Implement.
    /// <inheritdoc/>
    public string Render(IDictionary<INameable, int> scoreboard)
        => throw new NotImplementedException();
}
