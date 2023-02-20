using Serilog;

using Yatzy.Dices;
using Yatzy.PointsCalculators;
using Yatzy.Utils;

namespace Yatzy.Rules;
/// <summary>
/// Represents a rule which calculates the rules based on the same value and sums it up.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class SameValueRule<TDice> : IRule<TDice>
    where TDice : IDice
{
    readonly ILogger logger;
    readonly string identifier;
    readonly int face;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Creates an instance of the a same value rule.
    /// </summary>
    /// <param name="logger">The logger used throughtout the application.</param>
    /// <param name="identifier">Identifier which this rule will be named.</param>
    /// <param name="face">The value of the face its looking for.</param>
    /// <param name="pointsCalculator">The calculator to calculate points.</param>
    public SameValueRule(ILogger logger, string identifier, int face, IPointsCalculator pointsCalculator)
    {
        this.logger = logger.ForType<SameValueRule<TDice>>();
        this.identifier = identifier;
        this.face = face;
        this.pointsCalculator = pointsCalculator;
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points sum = Points.Empty;
        foreach (IDice dice in hand)
        {
            if (dice.Face != face)
                continue;
            sum += pointsCalculator.Calculate(face);
        }
        logger.Debug("Calculated points of the hand {Hand} to the amount of points {Points} with the rule specified as {Identifier}.", hand, sum, identifier);
        return sum;
    }
}
