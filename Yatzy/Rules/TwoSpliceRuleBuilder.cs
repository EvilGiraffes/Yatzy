using System.Diagnostics.CodeAnalysis;

using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
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
/// <see cref="PointsCalculator(IPointsCalculator)"/> <br/>
/// <see cref="CounterFactory(CounterFactory{int})"/>
/// </para>
/// <para>
/// After you have set everything you will need to call <see cref="Build"/>.
/// </para>
/// </remarks>
public sealed class TwoSplicedRuleBuilder<TDice> : IBuilder<TwoSplicedRule<TDice>>
    where TDice : IDice
{
    string? identifier = null;
    ISpliceStrategy? splicer = null;
    IPointsCalculator? pointsCalculator = null;
    CounterFactory<int>? counterFactory = null;
    readonly ILogger buildLogger;
    readonly ILogger internalLogger;
    /// <summary>
    /// Constructs a new <see cref="TwoSplicedRuleBuilder{TDice}"/>.
    /// </summary>
    /// <remarks>
    /// Logger is passed to the builder for internal logging aswell as being passed further to the <see cref="TwoSplicedRule{TDice}"/>.
    /// </remarks>
    /// <param name="logger">The logger used throughout this application.</param>
    public TwoSplicedRuleBuilder(ILogger logger)
    {
        buildLogger = logger;
        internalLogger = logger.ForType<TwoSplicedRuleBuilder<TDice>>();
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
    public TwoSplicedRule<TDice> Build()
    {
        if (AnyNull())
        {
            IEnumerable<string> nullParams = IdentifyNullValues();
            internalLogger.Error("The build has failed. The following parameters has not been overwritten: {NullParams}", nullParams);
            throw new BuildingContainedNullParameters
            {
                Parameters = nullParams
            };
        }
        return new TwoSplicedRule<TDice>(buildLogger, identifier, splicer, pointsCalculator, counterFactory);
    }
    [MemberNotNullWhen(
        false,
        nameof(identifier),
        nameof(splicer),
        nameof(pointsCalculator),
        nameof(counterFactory))]
    bool AnyNull()
        => identifier is null
        || splicer is null
        || pointsCalculator is null
        || counterFactory is null;
    IEnumerable<string> IdentifyNullValues()
    {
        if (identifier is null)
            yield return nameof(identifier);
        if (splicer is null)
            yield return nameof(splicer);
        if (pointsCalculator is null)
            yield return nameof(pointsCalculator);
        if (counterFactory is null)
            yield return nameof(counterFactory);
    }
}
