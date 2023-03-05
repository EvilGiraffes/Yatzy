using Yatzy.Dices;
using Yatzy.Extentions;
using Yatzy.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a rule which calculates the rules based on the same value and sums it up.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class SameValueRule<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type LogType
        => typeof(SameValueRule<TDice>);
    /// <inheritdoc/>
    public string Name { get; }
    // TODO: Handle unused values.
    readonly int face;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Creates an instance of the a same value rule.
    /// </summary>
    /// <param name="identifier">What to identify this rule as.</param>
    /// <param name="face">The value of the face its looking for.</param>
    /// <param name="pointsCalculator">The calculator to calculate points.</param>
    public SameValueRule(string identifier, int face, IPointsCalculator pointsCalculator)
    {
        Name = identifier;
        this.face = face;
        this.pointsCalculator = pointsCalculator;
    }


    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        if (hand.IsEmpty())
            return Points.Empty;
        Points sum = Points.Empty;
        foreach (IDice dice in hand)
        {
            if (dice.Face != face)
                continue;
            sum += pointsCalculator.Calculate(face);
        }
        return sum;
    }
}
