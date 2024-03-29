﻿using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a builder for <see cref="XPairs{TDice}"/>.
/// </summary>
/// <remarks>
/// <para>
/// Required methods to build <see cref="XPairs{TDice}"/>: <br/>
/// <see cref="X(int)"/> <br/>
/// <see cref="PointsCalculator(IPointsCalculator)"/>
/// </para>
/// </remarks>
/// <typeparam name="TDice"><inheritdoc cref="BuilderTemplate{TBuilding}" path="/typeparam"/></typeparam>
public sealed class XPairsBuilder<TDice> : BuilderTemplate<XPairs<TDice>>
    where TDice : IDice
{
    readonly ILogger logger;
    int? x = default;
    StringTransform<int>? xTransform = default;
    IPointsCalculator pointsCalculator = default!;
    CounterFactory<int>? counterFactory = default;
    Func<ISet<int>>? setFactory = default;
    internal XPairsBuilder(ILogger logger) : base(logger.ForType<XPairsBuilder<TDice>>())
    {
        this.logger = logger;
    }
    /// <summary>
    /// Sets the <paramref name="x"/> for the instance being created.
    /// </summary>
    /// <param name="x">The value for creation.</param>
    /// <returns><see langword="this"/> instance for further processing.</returns>
    public XPairsBuilder<TDice> X(int x)
    {
        this.x = x;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="StringTransform{TFrom}"/> for the instance being created.
    /// </summary>
    /// <param name="xTransform">The transform for the creation.</param>
    /// <returns><inheritdoc cref="X(int)" path="/returns"/></returns>
    public XPairsBuilder<TDice> XTransform(StringTransform<int> xTransform)
    {
        this.xTransform = xTransform;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="IPointsCalculator"/> for the instance being created.
    /// </summary>
    /// <param name="pointsCalculator">The calculator for the instance being created.</param>
    /// <returns><inheritdoc cref="X(int)" path="/returns"/></returns>
    public XPairsBuilder<TDice> PointsCalculator(IPointsCalculator pointsCalculator)
    {
        this.pointsCalculator = pointsCalculator;
        return this;
    }
    /// <summary>
    /// Sets the <see cref="CounterFactory{T}"/> for the instance being created.
    /// </summary>
    /// <param name="counterFactory">The counter factory for the instance being created.</param>
    /// <returns><inheritdoc cref="X(int)" path="/returns"/></returns>
    public XPairsBuilder<TDice> CounterFactory(CounterFactory<int> counterFactory)
    {
        this.counterFactory = counterFactory;
        return this;
    }
    /// <summary>
    /// Sets the set factory for the instance being created.
    /// </summary>
    /// <param name="setFactory">The set factory to use.</param>
    /// <returns><inheritdoc cref="X(int)" path="/returns"/></returns>
    public XPairsBuilder<TDice> SetFactory(Func<ISet<int>> setFactory)
    {
        this.setFactory = setFactory;
        return this;
    }
    /// <inheritdoc/>
    protected override IEnumerable<Member> RequiredMemberObjects()
    {
        yield return new(x);
        yield return new(pointsCalculator);
    }
    /// <inheritdoc/>
    protected override XPairs<TDice> Create()
    {
        xTransform ??= x => x.ToString();
        counterFactory ??= () => new HashCounter<int>(logger);
        setFactory ??= () => new HashSet<int>();
        return new(logger, (int) x!, xTransform, pointsCalculator, counterFactory, setFactory);
    }
}
