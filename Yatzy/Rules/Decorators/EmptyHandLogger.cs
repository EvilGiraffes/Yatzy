using Serilog;

using Yatzy.Decoration;
using Yatzy.Dices;
using Yatzy.Extentions;
using Yatzy.Logging;

namespace Yatzy.Rules.Decorators;
/// <summary>
/// A decorate to handle the event of the hand being empty.
/// </summary>
/// <remarks>The calculation will just fail unnoticed but will warn you with the logger, it will just return <see cref="Points.Empty"/> after logging.</remarks>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
public sealed class EmptyHandLogger<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type WrappedLogType
        => wrapped.WrappedLogType;
    /// <inheritdoc/>
    public string Name
        => wrapped.Name;
    readonly IRule<TDice> wrapped;
    readonly ILogger logger;
    /// <summary>
    /// Creates an instance of the <see cref="EmptyHandLogger{TDice}"/> decorator.
    /// </summary>
    /// <param name="wrapped">The rule it should wrap.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    public EmptyHandLogger(IRule<TDice> wrapped, ILogger logger)
    {
        this.wrapped = wrapped;
        this.logger = logger.ForType(wrapped.WrappedLogType);
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        if (!hand.IsEmpty())
            return wrapped.CalculatePoints(hand);
        logger.Warning("The hand is empty, cannot calculate the rules with an empty hand.");
        return Points.Empty;
    }
}
/// <summary>
/// Defines functions for wrapping an <see cref="IRule{TDice}"/> in an <see cref="Decorators.EmptyHandLogger{TDice}"/> instance.
/// </summary>
public static class EmptyHandLoggerWrappingExt
{
    /// <summary>
    /// Wraps the <see cref="IRule{TDice}"/> in an <see cref="Decorators.EmptyHandLogger{TDice}"/> instance.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="Decorators.EmptyHandLogger{TDice}" path="/typeparam"/></typeparam>
    /// <param name="context">The context of the rule it should wrap.</param>
    /// <param name="logger"><inheritdoc cref="EmptyHandLogger{TDice}.EmptyHandLogger(IRule{TDice}, ILogger)" path="/param[@name='logger']"/></param>
    /// <returns>A new instance of <see cref="Decorators.EmptyHandLogger{TDice}"/>.</returns>
    public static IRule<TDice> EmptyHandLogger<TDice>(this WrapperContext<IRule<TDice>> context, ILogger logger)
        where TDice : IDice
        => new EmptyHandLogger<TDice>(context.Context, logger);
}
