using System.Text;
using System.Text.Json;

using Serilog;

using Yatzy.Dices;

namespace Yatzy.Errors;
// TESTME: Test message is correct.
/// <summary>
/// Represents an exception thrown when the wanted value was not found in the hand.
/// </summary>
public class DiceIsNotInHand<TDice> : Exception
    where TDice : IDice
{
    /// <summary>
    /// The value attempted to find.
    /// </summary>
    public TDice Dice { get; init; } = default!;
    /// <summary>
    /// The hand the value was not found in.
    /// </summary>
    public IList<TDice> Hand { get; init; } = Array.Empty<TDice>();
    /// <inheritdoc/>
    public override string Message
    {
        get
        {
            StringBuilder builder = new();
            builder
                .Append(base.Message)
                .Append($" Value is defined as {Dice}.")
                .Append($" Hand is {JsonSerializer.Serialize(Hand)}.");
            return builder.ToString();
        }
    }
    /// <inheritdoc cref="Exception()"/>
    public DiceIsNotInHand()
    {
    }
    /// <inheritdoc cref="Exception(string?)"/>
    public DiceIsNotInHand(string? message) : base(message)
    {
    }
    /// <inheritdoc cref="Exception(string?, Exception?)"/>
    public DiceIsNotInHand(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    // TODO: Document if it is used.
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="hand"></param>
    /// <param name="dice"></param>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    /// <exception cref="DiceIsNotInHand{TDice}"></exception>
    public static void Guard(ILogger logger, IList<TDice> hand, TDice dice, string? message = null, Exception? inner = null)
    {
        if (hand.Contains(dice))
            return;
        logger.Error("The dice {Dice} is not in the hand {Hand}.", dice, hand);
        throw new DiceIsNotInHand<TDice>(message, inner)
        {
            Dice = dice,
            Hand = hand
        };
    }
}
