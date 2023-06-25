using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Rules;
// TESTME: Needs some testing.
/// <summary>
/// Represents a builder for <see cref="TwoSplicedRule{TDice}"/>.
/// </summary>
/// <remarks>
/// <para>
/// Required methods to set parameters: <br/>
/// <see cref="Identifier(string)"/> <br/>
/// <see cref="SpliceStrategy(ISpliceStrategy)"/> <br/>
/// <see cref="PointsCalculator(IPointsCalculator)"/>
/// </para>
/// </remarks>
public sealed class TwoSplicedRuleBuilder<TDice> : BuilderTemplate<TwoSplicedRule<TDice>>
    where TDice : IDice
{
    string identifier = default!;
    ISpliceStrategy splicer = default!;
    IPointsCalculator pointsCalculator = default!;
    CounterFactory<int>? counterFactory = default;
    readonly ILogger logger;
    /// <summary>
    /// Constructs a new <see cref="TwoSplicedRuleBuilder{TDice}"/>.
    /// </summary>
    /// <remarks>
    /// Logger is passed to the builder for internal logging aswell as being passed further to the <see cref="TwoSplicedRule{TDice}"/>.
    /// </remarks>
    /// <param name="logger">The logger used throughout this application.</param>
    public TwoSplicedRuleBuilder(ILogger logger)
        : base(logger.ForType<TwoSplicedRuleBuilder<TDice>>())
    {
        this.logger = logger;
    }
    /// <summary>
    /// Sets the identifier to be used for the instance to be created.
    /// </summary>
    /// <param name="identifier">
    /// <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='identifier']"/>
    /// </param>
    /// <returns><see langword="this"/> for further building.</returns>
    public TwoSplicedRuleBuilder<TDice> Identifier(string identifier)
    {
        this.identifier = identifier;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="ISpliceStrategy"/> to be used for the instance to be created.
    /// </summary>
    /// <param name="splicer">
    /// <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='splicer']"/>
    /// </param>
    /// <returns><inheritdoc cref="Identifier(string)" path="/returns"/></returns>
    public TwoSplicedRuleBuilder<TDice> SpliceStrategy(ISpliceStrategy splicer)
    {
        this.splicer = splicer;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="ISpliceStrategy"/> to be used for the instance to be created.
    /// </summary>
    /// <param name="pointsCalculator">
    /// <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='pointsCalculator']"/>
    /// </param>
    /// <returns><inheritdoc cref="Identifier(string)" path="/returns"/></returns>
    public TwoSplicedRuleBuilder<TDice> PointsCalculator(IPointsCalculator pointsCalculator)
    {
        this.pointsCalculator = pointsCalculator;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="ISpliceStrategy"/> to be used for the instance to be created.
    /// </summary>
    /// <param name="counterFactory">
    ///  <inheritdoc 
    /// cref="TwoSplicedRule{TDice}.TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='counterFactory']"/>
    /// </param>
    /// <returns><inheritdoc cref="Identifier(string)" path="/returns"/></returns>
    public TwoSplicedRuleBuilder<TDice> CounterFactory(CounterFactory<int> counterFactory)
    {
        this.counterFactory = counterFactory;
        return this;
    }
    /// <inheritdoc/>
    protected override IEnumerable<Member> RequiredMemberObjects()
    {
        yield return new(identifier);
        yield return new(splicer);
        yield return new(pointsCalculator);
    }
    /// <inheritdoc/>
    protected override TwoSplicedRule<TDice> Create()
    {
        counterFactory ??= () => new HashCounter<int>(logger);
        return new(logger, identifier, splicer, pointsCalculator, counterFactory);
    }
}
