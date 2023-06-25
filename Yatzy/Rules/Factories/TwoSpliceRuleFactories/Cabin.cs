using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Decoration;
using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Rules.Factories.TwoSpliceRuleFactories;
/// <summary>
/// Creates a Cabin rule with <see cref="TwoSplicedRule{TDice}"/> and the splicers <see cref="FullHouseSplicer"/> and <see cref="SplicerCountModifier"/>.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class Cabin<TDice> : IRuleFactory<TDice>
    where TDice : IDice
{
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int>? counterFactory;
    /// <summary>
    /// Constructs a new <see cref="Cabin{TDice}"/>.
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
    public Cabin(IPointsCalculator pointsCalculator, CounterFactory<int>? counterFactory = null)
    {
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
    }
    /// <inheritdoc/>
    public IRule<TDice> Create(ILogger logger)
    {
        ISpliceStrategy splicer = new FullHouseSplicer(logger);
        splicer = splicer.WrapIn().SplicerCountModifier(x => x - 1);
        TwoSplicedRuleBuilder<TDice> builder = TwoSplicedRule<TDice>.Builder(logger);
        builder
            .Identifier(nameof(Cabin<TDice>))
            .SpliceStrategy(splicer)
            .PointsCalculator(pointsCalculator);
        if (counterFactory is not null)
            builder.CounterFactory(counterFactory);
        return builder.Build();
    }
}
