using Yatzy.Dices;

namespace Yatzy.Rules;
/// <summary>
/// Defines a rule to calculate the points of a hand.
/// </summary>
public interface IRule<TDice>
    where TDice : IDice
{
    /// <summary>
    /// Calculates the points for this hand.
    /// </summary>
    /// <param name="hand">Current hand.</param>
    /// <returns>The points you recieve, 0 means you got no points.</returns>
    int Points(IList<TDice> hand);
}
