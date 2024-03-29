﻿using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a builder for <see cref="XOfAKind{TDice}"/>.
/// </summary>
/// <remarks>
/// <para>
/// Required methods build <see cref="XOfAKind{TDice}"/>: <br/>
/// <see cref="X"/> <br/>
/// <see cref="PointsCalculator(IPointsCalculator)"/>
/// </para>
/// </remarks>
/// <typeparam name="TDice"><inheritdoc cref="XOfAKind{TDice}" path="/typeparam"/></typeparam>
public sealed class XOfAKindBuilder<TDice> : BuilderTemplate<XOfAKind<TDice>>
    where TDice : IDice
{
    readonly ILogger logger;
    int? x = default;
    StringTransform<int>? xTransform = default;
    IPointsCalculator pointsCalculator = default!;
    CounterFactory<int>? counterFactory = default;
    internal XOfAKindBuilder(ILogger logger)
        : base(logger.ForType<XOfAKindBuilder<TDice>>())
    {
        this.logger = logger;
    }
    /// <summary>
    /// Sets the x to be used for the instance to be created.
    /// </summary>
    /// <param name="x">
    /// <inheritdoc
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='x']"/>
    /// </param>
    /// <returns><see langword="this"/> for further building.</returns>
    public XOfAKindBuilder<TDice> X(int x)
    {
        this.x = x;
        return this;
    }
    /// <summary>
    /// Sets the x transform to be used for the instance to be created.
    /// </summary>
    /// <param name="xTransform">
    ///  <inheritdoc
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='xTransform']"/>
    /// </param>
    /// <returns><inheritdoc cref="X" path="/returns"/></returns>
    public XOfAKindBuilder<TDice> XTransform(StringTransform<int> xTransform)
    {
        this.xTransform = xTransform;
        return this;
    }
    /// <summary>
    /// Sets the points calculator to be used for the instance to be created.
    /// </summary>
    /// <param name="pointsCalculator">
    ///  <inheritdoc
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='pointsCalculator']"/>
    /// </param>
    /// <returns><inheritdoc cref="X" path="/returns"/></returns>
    public XOfAKindBuilder<TDice> PointsCalculator(IPointsCalculator pointsCalculator)
    {
        this.pointsCalculator = pointsCalculator;
        return this;
    }
    /// <summary>
    /// Sets the counter factory to be used for the instance to be created.
    /// </summary>
    /// <param name="counterFactory">
    ///  <inheritdoc
    /// cref="XOfAKind{TDice}.XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})"
    /// path="/param[@name='counterFactory']"/>
    /// </param>
    /// <returns><inheritdoc cref="X" path="/returns"/></returns>
    public XOfAKindBuilder<TDice> CounterFactory(CounterFactory<int> counterFactory)
    {
        this.counterFactory = counterFactory;
        return this;
    }
    /// <inheritdoc/>
    protected override IEnumerable<Member> RequiredMemberObjects()
    {
        yield return new(x);
        yield return new(pointsCalculator);
    }
    /// <inheritdoc/>
    protected override XOfAKind<TDice> Create()
    {
        xTransform ??= x => x.ToString();
        counterFactory ??= () => new HashCounter<int>(logger);
        return new(logger, (int) x!, xTransform, pointsCalculator, counterFactory);
    }
}
