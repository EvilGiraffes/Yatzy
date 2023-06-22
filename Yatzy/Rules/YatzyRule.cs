using Serilog;

using Yatzy.Dices;
using Yatzy.Extentions;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a yatzy rule.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class YatzyRule<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public string Name
        => nameof(YatzyRule<TDice>);
    /// <summary>
    /// The default <see cref="IPointsCalculator"/> implementation.
    /// </summary>
    /// <value>Contains a <see cref="FixedPointsPerValue"/> calculator with the value of 10.</value>
    public static IPointsCalculator DefaultPointsCalculator
        => new FixedPointsPerValue(10);
    readonly ILogger logger;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Creates a new instance of <see cref="YatzyRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    public YatzyRule(ILogger logger) : this(logger, DefaultPointsCalculator)
    {
    }
    /// <summary>
    /// <inheritdoc cref="YatzyRule(ILogger)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="YatzyRule(ILogger)" path="/param[@name='logger']"/></param>'
    /// <param name="pointsCalculator">The calculator to calculate points for each value.</param>
    public YatzyRule(ILogger logger, IPointsCalculator pointsCalculator)
    {
        this.logger = logger.ForType<YatzyRule<TDice>>();
        this.pointsCalculator = pointsCalculator;
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyCollection<TDice> hand)
        => !hand.IsEmpty();
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyCollection<TDice> hand)
    {
        Points sum = Points.Empty;
        YatzyFace yatzy = YatzyFace.None;
        foreach (int face in hand.Select(dice => dice.Face))
        {
            yatzy = yatzy.TrackFace(face);
            if (face != yatzy.Face)
            {
                logger.Debug(
                    "The current face {Face} was inequal to the rest of the faces, therefore is not yatzy. Expected face {ExpectedFace}",
                    face, yatzy.Face);
                return Points.Empty;
            }
            sum += pointsCalculator.Calculate(yatzy.Face);
            logger.Verbose("Current sum is {Sum}", sum);
        }
        return sum;
    }
    readonly struct YatzyFace
    {
        public int Face { get; }
        public static YatzyFace None { get; } = new(0, true);
        readonly bool none;
        YatzyFace(int face, bool none)
        {
            Face = face;
            this.none = none;
        }
        public YatzyFace TrackFace(int face)
            => none
            ? new YatzyFace(face, false)
            : this;
    }
}
