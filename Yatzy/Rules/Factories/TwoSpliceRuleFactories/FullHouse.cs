using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Rules.Factories.TwoSpliceRuleFactories;
/// <summary>
/// Creates a full house <see cref="TwoSplicedRule{TDice}"/> with <see cref="FullHouseSplicer"/>.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class FullHouse<TDice> : IRuleFactory<TDice>
    where TDice : IDice
{
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int> counterFactory;
    /// <summary>
    /// Constructs a new <see cref="FullHouse{TDice}"/> factory.
    /// </summary>
    /// <param name="pointsCalculator">
    /// <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='pointsCalculator']"/>
    /// </param>
    /// <param name="counterFactory">
    /// <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='counterFactory']"/>
    /// </param>
    public FullHouse(IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory)
    {
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
    }
    /// <inheritdoc/>
    public IRule<TDice> Create(ILogger logger)
        => TwoSplicedRule<TDice>.Builder(logger)
        .Identifier(nameof(FullHouse<TDice>))
        .SpliceStrategy(new FullHouseSplicer(logger))
        .PointsCalculator(pointsCalculator)
        .CounterFactory(counterFactory)
        .Build();
}
