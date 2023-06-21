using Serilog;

using Yatzy.Decoration;
using Yatzy.Dices;
using Yatzy.Logging;

namespace Yatzy.Rules.Pipeline;
/// <summary>
/// Represents an <see cref="IRuleHandler{TDice}"/> which will log the result of each method call.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleHandler{TDice}" path="/typeparam"/></typeparam>
public sealed class LoggingHandler<TDice> : IRuleHandler<TDice>
    where TDice : IDice
{
    readonly ILogger logger;
    readonly IRuleHandler<TDice> wrapped;
    const string Applicable = "applicable";
    const string NotApplicable = "not " + Applicable;
    /// <summary>
    /// Constructs a new instance of <see cref="LoggingHandler{TDice}"/>.
    /// </summary>
    /// <param name="wrapped">The <see cref="IRuleHandler{TDice}"/> it wraps.</param>
    /// <param name="logger">The logger used throughout this application.</param>
    public LoggingHandler(IRuleHandler<TDice> wrapped, ILogger logger)
    {
        this.wrapped = wrapped;
        this.logger = logger.ForType<LoggingHandler<TDice>>();
    }
    /// <inheritdoc/>
    public bool IsApplicable(IRule<TDice> rule, IReadOnlyList<TDice> hand)
    {
        bool isApplicable = wrapped.IsApplicable(rule, hand);
        string applicability = RenderApplicability(isApplicable);
        logger.Debug("{Rule} is {Applicability} given {Hand}.", rule.Name, applicability, hand);
        return isApplicable;
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IRule<TDice> rule, IReadOnlyList<TDice> hand)
    {
        Points points = wrapped.CalculatePoints(rule, hand);
        logger.Debug("{Rule} yielded {Points} with the given {Hand}.", rule.Name, points, hand);
        return points;
    }
    static string RenderApplicability(bool isApplicable)
        => isApplicable
        ? Applicable
        : NotApplicable;
}
/// <summary>
/// Represents implementation of wrapping <see cref="Pipeline.LoggingHandler{TDice}"/> in another <see cref="IRuleHandler{TDice}"/>.
/// </summary>
public static class LoggingHandlerWrapper
{
    /// <summary>
    /// Wraps the given <see cref="IRuleHandler{TDice}"/> in <see cref="Pipeline.LoggingHandler{TDice}"/>.
    /// </summary>
    /// <typeparam name="TDice"><inheritdoc cref="Pipeline.LoggingHandler{TDice}" path="/typeparam"/></typeparam>
    /// <param name="wrapped">
    /// <inheritdoc 
    /// cref="LoggingHandler{TDice}.LoggingHandler(IRuleHandler{TDice}, ILogger)"
    /// path="/param[@name='wrapped']"/>
    /// </param>
    /// <param name="logger">
    /// <inheritdoc 
    /// cref="LoggingHandler{TDice}.LoggingHandler(IRuleHandler{TDice}, ILogger)"
    /// path="/param[@name='logger']"/>
    /// </param>
    /// <returns></returns>
    public static IRuleHandler<TDice> LoggingHandler<TDice>(this WrapperContext<IRuleHandler<TDice>> wrapped, ILogger logger)
        where TDice : IDice
        => new LoggingHandler<TDice>(wrapped.Context, logger);
}