using Serilog;

using Yatzy.Dices;
using Yatzy.Utils;

namespace Yatzy.Rules;
// TESTME: Ensure it calculates points according to specifications.
/// <summary>
/// Represents a rule which calculates the rules based on the same value and sums it up.
/// </summary>
public sealed class SameValueRule : IRule<IDice>
{
    readonly ILogger logger;
    readonly string identifier;
    readonly int value;
    readonly int pointsPerValue;
    /// <summary>
    /// Creates an instance of the a same value rule.
    /// </summary>
    /// <param name="logger">The logger used throughtout the application.</param>
    /// <param name="identifier">Identifier which this rule will be named.</param>
    /// <param name="value">The value of the face its looking for.</param>
    /// <param name="pointsPerValue">How many points given per value found.</param>
    public SameValueRule(ILogger logger, string identifier, int value, int pointsPerValue)
    {
        this.logger = logger.ForType<SameValueRule>();
        this.identifier = identifier;
        this.value = value;
        this.pointsPerValue = pointsPerValue;
    }

    public int Points(IList<IDice> hand)
    {
        int sum = 0;
        foreach (IDice dice in hand)
        {
            if (dice.Face != value)
                continue;
            sum += pointsPerValue;
        }
        logger.Debug("Calculated points of the hand {Hand} to the sum {Sum} with the rule specified as {Identifier}.", hand, sum, identifier);
        return sum;
    }
}
