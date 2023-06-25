using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories;
/// <summary>
/// Represents a factory to create <see cref="XOfAKind{TDice}"/>.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class XOfAKindFactory<TDice> : IRuleFactory<TDice>
    where TDice : IDice
{
    readonly int x;
    readonly IPointsCalculator pointsCalculator;
    readonly StringTransform<int>? xTransform;
    readonly CounterFactory<int>? counterFactory;
    XOfAKindFactory(int x, IPointsCalculator pointsCalculator, StringTransform<int>? xTransform, CounterFactory<int>? counterFactory)
    {
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.xTransform = xTransform;
        this.counterFactory = counterFactory;
    }
    /// <inheritdoc/>
    public IRule<TDice> Create(ILogger logger)
    {
        XOfAKindBuilder<TDice> builder = XOfAKind<TDice>.Builder(logger);
        builder
            .X(x)
            .PointsCalculator(pointsCalculator);
        if (xTransform is not null)
            builder.XTransform(xTransform);
        if (counterFactory is not null)
            builder.CounterFactory(counterFactory);
        return builder.Build();
    }
    /// <summary>
    /// Creates a partial implementation of <see cref="XOfAKindFactory{TDice}"/>.
    /// </summary>
    /// <param name="pointsCalculator">
    /// <inheritdoc 
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='pointsCalculator']"/>
    /// </param>
    /// <param name="xTransform">
    /// <inheritdoc 
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='xTransform']"/>
    /// </param>
    /// <param name="counterFactory">
    /// <inheritdoc 
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='counterFactory']"/>
    /// </param>
    /// <returns>A new partial implementation of <see cref="XOfAKindFactory{TDice}"/>.</returns>
    public static Func<int, XOfAKindFactory<TDice>> Partial(IPointsCalculator pointsCalculator, StringTransform<int>? xTransform = null, CounterFactory<int>? counterFactory = null)
        => x => new(x, pointsCalculator, xTransform, counterFactory);
}
