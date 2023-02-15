using System.Text;
using System.Text.Json;

using Serilog;

using Yatzy.Dices;

namespace Yatzy.Errors;
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
    public override string Message
        => BuildMessage();
    public DiceIsNotInHand()
    {
    }

    public DiceIsNotInHand(string? message) : base(message)
    {
    }

    public DiceIsNotInHand(string? message, Exception? inner) : base(message, inner)
    {
    }
    // TODO: Document if it is used.
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

    string BuildMessage()
    {
        StringBuilder builder = new();
        builder
            .AppendLine(base.Message)
            .AppendLine($"Value is defined as {Dice}.")
            .AppendLine($"Hand is {JsonSerializer.Serialize(Hand)}.");
        return builder.ToString();

    }
}
