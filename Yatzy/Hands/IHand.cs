using Yatzy.Dices;
using Yatzy.Errors;

namespace Yatzy.Hands;
/// <summary>
/// Defines the current hand.
/// </summary>
/// <typeparam name="TDice">The dice in which this hand can hold.</typeparam>
public interface IHand<TDice> : IReadOnlyList<TDice>
    where TDice : IDice
{
    /// <summary>
    /// Keeps the current value in the hand.
    /// </summary>
    /// <param name="dice">The dice to keep.</param>
    /// <exception cref="DiceIsNotInHand{TDice}">Thrown when the dice cannot be found in the current hand.</exception>
    void Keep(TDice dice);
    /// <summary>
    /// Rolls all the dice in the hand.
    /// </summary>
    void Roll();
}
