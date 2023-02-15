using Yatzy.Dices;
using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Defines the current hand.
/// </summary>
public interface IHand<TDice>
    where TDice : IDice
{
    /// <summary>
    /// The current hand defined by <typeparamref name="TDice"/>.
    /// </summary>
    IList<TDice> CurrentHand { get; }
    /// <summary>
    /// Keeps the current value in the hand.
    /// </summary>
    /// <param name="dice">The dice to keep.</param>
    /// <exception cref="DiceIsNotInHand">Thrown when the dice cannot be found in the current hand.</exception>
    void Keep(TDice dice);
    void Roll();
}
