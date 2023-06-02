using Serilog;

using Yatzy.Dices;
using Yatzy.Extentions;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a rule which calculates the rules based on the same value and sums it up.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class SameValueRule<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public string Name { get; }
    readonly ILogger logger;
    readonly int face;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Creates an instance of the a same value rule.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="identifier">What to identify this rule as.</param>
    /// <param name="face">The value of the face its looking for.</param>
    /// <param name="pointsCalculator">The calculator to calculate points.</param>
    public SameValueRule(ILogger logger, string identifier, int face, IPointsCalculator pointsCalculator)
    {
        this.logger = logger.ForType<SameValueRule<TDice>>();
        Name = identifier;
        this.face = face;
        this.pointsCalculator = pointsCalculator;
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyList<TDice> hand)
        => !hand.IsEmpty();
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points sum = Points.Empty;
        foreach (IDice dice in hand)
        {
            if (dice.Face != face)
            {
                logger.Verbose("Face is not equal, sum remains unchanged.");
                continue;
            }
            sum += pointsCalculator.Calculate(face);
            logger.Verbose("Current sum is {Sum}", sum);
        }
        return sum;
    }
}
