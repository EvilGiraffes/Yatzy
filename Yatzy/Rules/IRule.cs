using Yatzy.Dices;

namespace Yatzy.Rules;
/// <summary>
/// Defines a rule to calculate the points of a hand.
/// </summary>
/// <typeparam name="TDice">The dice in which this rule will be applicable for.</typeparam>
public interface IRule<TDice>
    where TDice : IDice
{
    /// <summary>
    /// Calculates the points for this hand.
    /// </summary>
    /// <param name="hand">Current hand.</param>
    /// <returns>A <see cref="Points"/> structure which will tell you if you got points and how much you got.</returns>
    Points CalculatePoints(IReadOnlyList<TDice> hand);
}
