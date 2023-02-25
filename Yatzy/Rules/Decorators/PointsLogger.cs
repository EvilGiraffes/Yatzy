using Serilog;

using Yatzy.Decoration;
using Yatzy.Dices;
using Yatzy.Logging;

namespace Yatzy.Rules.Decorators;
/// <summary>
/// Represents a logger decorator which logs the points recieved.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class PointsLogger<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type LogType
        => wrapped.LogType;
    /// <inheritdoc/>
    public string Name
        => wrapped.Name;
    readonly ILogger logger;
    readonly IRule<TDice> wrapped;
    /// <summary>
    /// Constructs a new instance of <see cref="PointsLogger{TDice}"/>
    /// </summary>
    /// <param name="wrapped">The rule it should wrap.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    public PointsLogger(IRule<TDice> wrapped, ILogger logger)
    {
        this.logger = logger.ForType(wrapped.LogType);
        this.wrapped = wrapped;
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points points = wrapped.CalculatePoints(hand);
        logger.Debug("Calculated the points {Points}.", points);
        return points;
    }
}
// TODO: Find smoother way to write wrappings.
/// <summary>
/// Wraps an <see cref="IRule{TDice}"/> in <see cref="Decorators.PointsLogger{TDice}"/>.
/// </summary>
public static class PointsLoggerWrapperExt
{
    /// <summary>
    /// Will wrap the <see cref="IRule{TDice}"/> in a <see cref="Decorators.PointsLogger{TDice}"/>.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="Decorators.PointsLogger{TDice}"/></typeparam>
    /// <param name="context">The context of the rule it should wrap.</param>
    /// <param name="logger"><inheritdoc cref="PointsLogger{TDice}.PointsLogger(IRule{TDice}, ILogger)" path="/param[@name='logger']"/></param>
    /// <returns>A new instance of <see cref="Decorators.PointsLogger{TDice}"/>.</returns>
    public static IRule<TDice> PointsLogger<TDice>(this WrapperContext<IRule<TDice>> context, ILogger logger)
        where TDice : IDice
        => new PointsLogger<TDice>(context.Context, logger);
}
