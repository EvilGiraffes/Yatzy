using Serilog;

using Yatzy.Decoration;
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
    /// <inheritdoc/>
    public string Name
        => wrapped.Name;
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
/// Defines functions for wrapping an <see cref="IRule{TDice}"/> in an <see cref="Decorators.EmptyHandHandler{TDice}"/> instance.
/// </summary>
public static class EmptyHandlerWrappingExt
{
    /// <summary>
    /// Wraps the <see cref="IRule{TDice}"/> in an <see cref="Decorators.EmptyHandHandler{TDice}"/> instance.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="Decorators.EmptyHandHandler{TDice}" path="/typeparam"/></typeparam>
    /// <param name="context">The context of the rule it should wrap.</param>
    /// <param name="logger"><inheritdoc cref="EmptyHandHandler{TDice}.EmptyHandHandler(IRule{TDice}, ILogger)" path="/param[@name='logger']"/></param>
    /// <returns>A new instance of <see cref="Decorators.EmptyHandHandler{TDice}"/>.</returns>
    public static IRule<TDice> EmptyHandHandler<TDice>(this WrapperContext<IRule<TDice>> context, ILogger logger)
        where TDice : IDice
        => new EmptyHandHandler<TDice>(context.Context, logger);
}
