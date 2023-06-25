using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories;
/// <summary>
/// Represents a factory for <see cref="XPairs{TDice}"/>.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="XPairs{TDice}" path="/typeparam"/></typeparam>
public sealed class XPairsFactory<TDice> : IRuleFactory<TDice>
    where TDice : IDice
{
    readonly int x;
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int>? counterFactory;
    readonly Func<ISet<int>>? setFactory;

    XPairsFactory(int x, IPointsCalculator pointsCalculator, CounterFactory<int>? counterFactory, Func<ISet<int>>? setFactory)
    {
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        this.setFactory = setFactory;
    }
    /// <inheritdoc/>
    public IRule<TDice> Create(ILogger logger)
    {
        XPairsBuilder<TDice> builder = XPairs<TDice>.Builder(logger);
        builder
            .X(x)
            .PointsCalculator(pointsCalculator);
        if (counterFactory is not null)
            builder.CounterFactory(counterFactory);
        if (setFactory is not null)
            builder.SetFactory(setFactory);
        return builder.Build();
    }
    /// <summary>
    /// Creates a partial factory where only X will be given.
    /// </summary>
    /// <param name="pointsCalculator">
    /// <inheritdoc 
    /// cref="XPairs{TDice}.XPairs(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int}, Func{ISet{int}})"
    /// path="/param[@name='pointsCalculator']"/>
    /// </param>
    /// <param name="counterFactory">
    /// <inheritdoc 
    /// cref="XPairs{TDice}.XPairs(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int}, Func{ISet{int}})"
    /// path="/param[@name='counterFactory']"/>
    /// </param>
    /// <param name="setFactory">
    /// <inheritdoc 
    /// cref="XPairs{TDice}.XPairs(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int}, Func{ISet{int}})"
    /// path="/param[@name='setFactory']"/>
    /// </param>
    /// <returns>A partial implementation of this factory.</returns>
    public static Func<int, XPairsFactory<TDice>> Partial(IPointsCalculator pointsCalculator, CounterFactory<int>? counterFactory = null, Func<ISet<int>>? setFactory = null)
        => x => new(x, pointsCalculator, counterFactory, setFactory);
}
