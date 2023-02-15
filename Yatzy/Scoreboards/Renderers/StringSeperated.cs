using Serilog;

using Yatzy.Utils;

namespace Yatzy.Scoreboards.Renderers;
/// <summary>
/// Represents a renderer who will render it as a simple line with the provided seperators.
/// </summary>
/// <typeparam name="TKey"><inheritdoc cref="IRenderer{Tkey}" path="/typeparam"/></typeparam>
public sealed class StringSeperated<TKey> : IRenderer<TKey>
    where TKey : INameable
{
    public readonly static string DefaultSeperator = Environment.NewLine;
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
        this.logger = logger.ForType<StringSeperated<TKey>>();
        seperator ??= DefaultSeperator;
        this.seperator = seperator;
        keyValueSeperator ??= DefaultKeyValueSeperator;
        this.keyValueSeperator = keyValueSeperator;
    }
    // TODO: Implement.
    /// <inheritdoc/>
    public string Render(IDictionary<TKey, int> scoreboard)
        => throw new NotImplementedException();
}
