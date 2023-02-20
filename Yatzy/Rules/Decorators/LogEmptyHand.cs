using Serilog;

using Yatzy.Dices;

namespace Yatzy.Rules.Decorators;
/// <summary>
/// Decorates a rule to log the event of the hand being empty.
/// </summary>
/// <remarks>The calculation will just fail unnoticed but will warn you with the logger, it will just return <see cref="Points.Empty"/> after logging.</remarks>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
public sealed class LogEmptyHand<TDice> : IRule<TDice>
    where TDice : IDice
{
    readonly IRule<TDice> wrapped;
    readonly ILogger logger;
    /// <summary>
    /// Creates an instance of the <see cref="LogEmptyHand{TDice}"/> decorator.
    /// </summary>
    /// <param name="wrapped">The rule it should wrap.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    public LogEmptyHand(IRule<TDice> wrapped, ILogger logger)
    {
        this.wrapped = wrapped;
        this.logger = logger;
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        if (hand.Count > 0)
            return wrapped.CalculatePoints(hand);
        logger.Warning("The hand is empty, cannot calculate the rules with an empty hand.");
        return Points.Empty;
    }
}
/// <summary>
/// Extentions to wrap instances with <see cref="LogEmptyHand{TDice}"/>
/// </summary>
public static class LogEmptyHandWrappingExt
{
    /// <summary>
    /// Wraps the current rule in an instance of <see cref="LogEmptyHand{TDice}"/>.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="LogEmptyHand{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
    /// <param name="rule">The rule to wrap in <see cref="LogEmptyHand{TDice}"/>.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <returns>A new <see cref="IRule{TDice}"/> wrapped in <see cref="LogEmptyHand{TDice}"/>.</returns>
    public static IRule<TDice> WrapInLogEmptyHand<TDice>(this IRule<TDice> rule, ILogger logger)
        where TDice : IDice
        => new LogEmptyHand<TDice>(rule, logger);
}

