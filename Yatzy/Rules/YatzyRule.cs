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
        using IEnumerator<int> faceEnumerator = hand.Select(dice => dice.Face).GetEnumerator();
        faceEnumerator.MoveNext();
        Points sum = Points.Empty;
        int yatzyFace = faceEnumerator.Current;
        do
        {
            int face = faceEnumerator.Current;
            if (face != yatzyFace)
            {
                logger.Debug(
                    "The current face {Face} was inequal to the rest of the faces, therefore is not yatzy. Expected face {ExpectedFace}",
                    face, yatzyFace);
                return Points.Empty;
            }
            sum += pointsCalculator.Calculate(face);
            logger.Verbose("Current sum is {Sum}", sum);
        }
        while (faceEnumerator.MoveNext());
        return sum;
    }
}
