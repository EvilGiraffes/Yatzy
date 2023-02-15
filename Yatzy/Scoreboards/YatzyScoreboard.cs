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
                logger.Information("There is no arguments.");
                return;
            }
            Action<string> logInfo = action =>
                logger.Information("{Action} {Name}, defined as {@Player}", action, args.Player.Name, args.Player);
            if (!scores.ContainsKey(args.Player))
            {
                logInfo("Creating");
                scores[args.Player] = args.PointsRecieved;
                return;
            }
            logInfo("Updating");
            scores[args.Player] += args.PointsRecieved;
        };
    readonly IDictionary<Player, int> scores;
    readonly IRenderer<Player> renderer;
    readonly ILogger logger;
    /// <summary>
    /// Creates a new instance of a yatzy scoreboard.
    /// </summary>
    /// <param name="logger">The logger used throughout the application.</param>
    public YatzyScoreboard(ILogger logger) : this(logger, null, null)
    {
    }
    /// <inheritdoc cref="YatzyScoreboard(ILogger)"/>
    /// <param name="renderer">The renderer to use for rendering the scores.</param>
    public YatzyScoreboard(ILogger logger, IRenderer<Player> renderer) : this(logger, renderer, null)
    {
    }
    /// <inheritdoc cref="YatzyScoreboard(ILogger, IRenderer{Player})"/>
    /// <param name="scores">The startup scores to use.</param>
    public YatzyScoreboard(ILogger logger, IRenderer<Player>? renderer, IDictionary<Player, int>? scores)
    {
        this.logger = logger.ForType<YatzyScoreboard>();
        renderer ??= new StringSeperated<Player>(logger);
        this.renderer = renderer;
        scores ??= new Dictionary<Player, int>();
        this.scores = scores;
    }
    /// <inheritdoc/>
    public string RenderScores()
        => renderer.Render(scores);
}
