using Serilog;

using Yatzy.Dices;
using Yatzy.Utils;

namespace Yatzy.DiceStates;
/// <summary>
/// Represents a state where the dice is held.
/// </summary>
public sealed class HeldState : IDiceState
{
    readonly ILogger logger;
    public HeldState(ILogger logger)
    {
        this.logger = logger.ForType<HeldState>();
    }

    /// <summary>
    /// Will not roll the dice, rather keep it as it is.
    /// </summary>
    /// <param name="context"><inheritdoc cref="IDiceState.Roll(DynamicDice)" path="/param[@name='context']"/></param>
    /// <returns>As it is held it will return the face back.</returns>
    public int Roll(IDice context, DiceRange _)
    {
        logger.Debug(
            "Holds the value and returns the face of the dice context, defined as {Face}, from context {Context}",
            context.Face, context);
        return context.Face;
    }
}
