using Serilog;

using Yatzy.Dices;
using Yatzy.Logging;

namespace Yatzy.DiceStates;
/// <summary>
/// Represents a state where the dice is held.
/// </summary>
public sealed class HeldState : IDiceState
{
    readonly ILogger logger;
    /// <summary>
    /// Constructs a new instance of the <see cref="HeldState"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    public HeldState(ILogger logger)
    {
        this.logger = logger.ForType<HeldState>();
    }

    /// <summary>
    /// Will not roll the dice, rather keep it as it is.
    /// </summary>
    /// <param name="context"><inheritdoc cref="IDiceState.Roll(IDice, DiceRange)" path="/param[@name='context']"/></param>
    /// <param name="_">Dice range isnt used in this instance.</param>
    /// <returns>As it is held it will return the face back.</returns>
    public int Roll(IDice context, DiceRange _)
    {
        logger.Debug(
            "Holds the value and returns the face of the dice context, defined as {Face}, from context {Context}",
            context.Face, context);
        return context.Face;
    }
}
