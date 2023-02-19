using Serilog;

using Yatzy.Scoreboards.Renderers;
using Yatzy.Utils;

namespace Yatzy.Scoreboards;
/// <summary>
/// Represents a simple implementation of a yatzy scoreboard.
/// </summary>
public sealed class YatzyScoreboard : IScoreboard<YatzyEventArgs>
{
    /// <inheritdoc/>
    public Action<YatzyEventArgs?> SubscriberCallback
        => args =>
        {
            if (args is null)
            {
                logger.Debug("There is no arguments.");
                return;
            }
            Action<string> logDebug = action =>
                logger.Debug("{Action} {Name}, defined as {@Player}", action, args.Player.Name, args.Player);
            if (!scores.ContainsKey(args.Player))
            {
                logDebug("Creating");
                scores[args.Player] = args.PointsRecieved;
                return;
            }
            logDebug("Updating");
            scores[args.Player] += args.PointsRecieved;
        };
    readonly IDictionary<INameable, int> scores;
    readonly IRenderer renderer;
    readonly ILogger logger;
    /// <summary>
    /// Creates a new instance of <see cref="YatzyScoreboard"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="renderer">The renderer to format the scores with.</param>
    public YatzyScoreboard(ILogger logger, IRenderer renderer)
        : this(logger, renderer, new Dictionary<INameable, int>())
    {
    }
    /// <summary>
    /// <inheritdoc cref="YatzyScoreboard(ILogger, IRenderer)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="YatzyScoreboard(ILogger, IRenderer)" path="/param[@name='logger']"/></param>
    /// <param name="renderer"><inheritdoc cref="YatzyScoreboard(ILogger, IRenderer)" path="/param[@name='renderer']"/></param>
    /// <param name="scores">The scoreboard being wrapped.</param>
    public YatzyScoreboard(ILogger logger, IRenderer renderer, IDictionary<INameable, int> scores)
    {
        this.logger = logger.ForType<YatzyScoreboard>();
        this.renderer = renderer;
        this.scores = scores;
    }
    /// <inheritdoc/>
    public string RenderScores()
        => renderer.Render(scores);
}
