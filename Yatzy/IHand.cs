using Yatzy.Dices;

namespace Yatzy;
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
    /// <exception cref="DiceIsNotInHand">Thrown when the dice cannot be found in the current hand.</exception>
    void Keep(TDice dice);
    void Roll();
}
