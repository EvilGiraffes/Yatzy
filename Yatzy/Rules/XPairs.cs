﻿using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents an <see cref="IRule{TDice}"/> which checks an X amount of pairs.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class XPairs<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public string Name { get; }
    readonly ILogger logger;
    readonly int x;
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int> counterFactory;
    readonly Func<ISet<int>> setFactory;
    internal const int Minimum = 1;
    internal const int Maximum = int.MaxValue;
    /// <summary>
    /// Constructs a new <see cref="XPairs{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="x">The amount of pairs you're looking for.</param>
    /// <param name="xTransform">The transformation for <paramref name="x"/> to name the instance with <see cref="XPairs{TDice}.Name"/>.</param>
    /// <param name="pointsCalculator">The strategy to calculate points based on.</param>
    /// <param name="counterFactory">The factory to create a counter.</param>
    /// <param name="setFactory">The factory to create an <see cref="ISet{T}"/>.</param>
    /// <exception cref="XOutOfRange">Thrown when <paramref name="x"/> is out of range.</exception>
    internal XPairs(ILogger logger, int x, StringTransform<int> xTransform, IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory, Func<ISet<int>> setFactory)
    {
        this.logger = logger.ForType<XPairs<TDice>>();
        XOutOfRange.Guard(this.logger, x, Minimum, Maximum);
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        this.setFactory = setFactory;
        Name = $"{xTransform(x)}Pairs";
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyCollection<TDice> hand)
        => hand.Count >= x * 2;
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyCollection<TDice> hand)
    {
        Points sum = Points.Empty;
        ICounter<int> counter = counterFactory();
        ISet<int> calculated = setFactory();
        foreach (int face in hand.Select(dice => dice.Face))
        {
            counter.Count(face);
            if (counter[face] < 2)
            {
                logger.Verbose("Count of {Face} has not reached enough to be a pair.", face);
                continue;
            }
            if (calculated.Contains(face))
            {
                logger.Verbose("{Face} has already been calculated.", face);
                continue;
            }
            Points given = pointsCalculator.Calculate(face) * 2;
            sum += given;
            logger.Debug("Given {Given} for the face {Face} in the hand {Hand}.", given, face, hand);
            logger.Debug("Current sum is {Sum}", sum);
            calculated.Add(face);
        }
        return sum;
    }
    /// <summary>
    /// Creates a new <see cref="XPairsBuilder{TDice}"/> to construct an instance of <see cref="XPairs{TDice}"/>.
    /// </summary>
    /// <param name="logger">the logger used throughout this application.</param>
    /// <returns>A new <see cref="XPairsBuilder{TDice}"/>.</returns>
    public static XPairsBuilder<TDice> Builder(ILogger logger)
        => new(logger);
}
