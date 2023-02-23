using Serilog;

using Yatzy.Dices;
using Yatzy.Logging;

namespace Yatzy.Rules.Decorators;
// TESTME: Needs some testing.
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
    readonly ILogger logger;
    readonly IRule<TDice> wrapped;
    /// <summary>
    /// Constructs a new instance of <see cref="PointsLogger{TDice}"/>
    /// </summary>
    /// <param name="wrapped">The <see cref="IRule{TDice}"/> it wraps.</param>
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
/// Wraps an <see cref="IRule{TDice}"/> in <see cref="PointsLogger{TDice}"/>.
/// </summary>
public static class PointsLoggerWrapperExt
{
    /// <summary>
    /// Will wrap the current rule in a <see cref="PointsLogger{TDice}"/>.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="PointsLogger{TDice}" path="/typeparam"/></typeparam>
    /// <param name="rule"><inheritdoc cref="PointsLogger{TDice}.PointsLogger(IRule{TDice}, ILogger)" path="/param[@name='wrapped']"/></param>
    /// <param name="logger"><inheritdoc cref="PointsLogger{TDice}.PointsLogger(IRule{TDice}, ILogger)" path="/param[@name='logger']"/></param>
    /// <returns>A new <see cref="PointsLogger{TDice}"/> wrapped with <see cref="IRule{TDice}"/>.</returns>
    public static IRule<TDice> WrapInPointsLogger<TDice>(this IRule<TDice> rule, ILogger logger)
        where TDice : IDice
        => new PointsLogger<TDice>(rule, logger);
}
