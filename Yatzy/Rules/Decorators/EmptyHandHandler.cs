using Serilog;

using Yatzy.Dices;
using Yatzy.Logging;

namespace Yatzy.Rules.Decorators;
/// <summary>
/// A decorate to handle the event of the hand being empty.
/// </summary>
/// <remarks>The calculation will just fail unnoticed but will warn you with the logger, it will just return <see cref="Points.Empty"/> after logging.</remarks>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
public sealed class EmptyHandHandler<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type LogType
        => wrapped.LogType;
    readonly IRule<TDice> wrapped;
    readonly ILogger logger;
    /// <summary>
    /// Creates an instance of the <see cref="EmptyHandHandler{TDice}"/> decorator.
    /// </summary>
    /// <param name="wrapped">The rule it should wrap.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    public EmptyHandHandler(IRule<TDice> wrapped, ILogger logger)
    {
        this.wrapped = wrapped;
        this.logger = logger.ForType(wrapped.LogType);
    }


    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        if (hand.Count > 0)
            return wrapped.CalculatePoints(hand);
        logger.Warning("The hand is empty, cannot calculate the rules with an empty hand.");
        return Points.Empty;
    }
    /// <summary>
    /// Gets the type of the wrapped object.
    /// </summary>
    /// <returns></returns>
    new public Type GetType()
        => wrapped.GetType();
}
/// <summary>
/// Defines functions for wrapping an <see cref="IRule{TDice}"/> in <see cref="EmptyHandHandler{TDice}"/>.
/// </summary>
public static class EmptyHandlerWrappingExt
{
    /// <summary>
    /// Wraps the current rule in an instance of <see cref="EmptyHandHandler{TDice}"/>.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="EmptyHandHandler{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
    /// <param name="rule">The rule to wrap in <see cref="EmptyHandHandler{TDice}"/>.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <returns>A new <see cref="IRule{TDice}"/> wrapped in <see cref="EmptyHandHandler{TDice}"/>.</returns>
    public static IRule<TDice> WrapInLogEmptyHand<TDice>(this IRule<TDice> rule, ILogger logger)
        where TDice : IDice
        => new EmptyHandHandler<TDice>(rule, logger);
}
