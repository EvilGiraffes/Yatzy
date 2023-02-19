using Serilog;

using Yatzy.Dices;
using Yatzy.Utils;

namespace Yatzy.Rules;
/// <summary>
/// Represents a rule which calculates the rules based on the same value and sums it up.
/// </summary>
public sealed class SameValueRule : IRule<IDice>
{
    readonly ILogger logger;
    readonly string identifier;
    readonly int face;
    readonly Points pointsPerValue;
    /// <summary>
    /// Creates an instance of the a same value rule.
    /// </summary>
    /// <param name="logger">The logger used throughtout the application.</param>
    /// <param name="identifier">Identifier which this rule will be named.</param>
    /// <param name="face">The value of the face its looking for.</param>
    /// <param name="pointsPerValue">How many points given per value found.</param>
    public SameValueRule(ILogger logger, string identifier, int face, Points pointsPerValue)
    {
        this.logger = logger.ForType<SameValueRule>();
        this.identifier = identifier;
        this.face = face;
        this.pointsPerValue = pointsPerValue;
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<IDice> hand)
    {
        Points sum = Points.Empty;
        foreach (IDice dice in hand)
        {
            if (dice.Face != face)
                continue;
            sum += pointsPerValue;
        }
        logger.Debug("Calculated points of the hand {Hand} to the amount of points {Points} with the rule specified as {Identifier}.", hand, sum, identifier);
        return sum;
    }
}
