using Serilog;

using Yatzy.Logging;
using Yatzy.RandomizerProviders;

namespace Yatzy.Dices.States;
/// <summary>
/// Represents a state where the dice is free to roll.
/// </summary>
public sealed class NotHeldState : IDiceState
{
    readonly ILogger logger;
    readonly IRandomizerProvider randomizer;
    /// <summary>
    /// Constructs a new instance of the state.
    /// </summary>
    /// <param name="logger">The logger instance used throughtout the application.</param>
    /// <param name="randomizer">A provider to randomize the value.</param>
    public NotHeldState(ILogger logger, IRandomizerProvider randomizer)
    {
        this.logger = logger.ForType<NotHeldState>();
        this.randomizer = randomizer;
    }
    /// <summary>
    /// Will roll a dice as defined by the <see cref="IRandomizerProvider"/> provider.
    /// </summary>
    /// <param name="context"><inheritdoc cref="IDiceState.Roll(IDice, DiceRange)" path="/param[@name='context']"/></param>
    /// <param name="range"><inheritdoc cref="IDiceState.Roll(IDice, DiceRange)" path="/param[@name='range']"/></param>
    /// <returns>A new <see cref="int"/> based on the randomization.</returns>
    public int Roll(IDice context, DiceRange range)
    {
        (int min, int max) = range;
        int value = randomizer.Next(min, max + 1);
        logger.Debug(
            "Rolled the value {Value} using a randomizer defined as {Randomizer} from dice range {DiceRange} with inclusive bounds. Current context is {Context}",
            value, randomizer, range, context);
        return value;
    }
}
