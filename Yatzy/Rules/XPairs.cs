using Serilog;

using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a class which checks an X amount of pairs.
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
    internal XPairs(ILogger logger, int x, StringTransform<int> xTransform, IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory)
    {
        this.logger = logger;
        XOutOfRange.Guard(logger, x, Minimum, Maximum);
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        Name = $"{xTransform(x)}Pairs";
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyList<TDice> hand)
        => hand.Count >= x * 2;
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points sum = Points.Empty;
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        foreach (Count<int> count in counter.FilterByAmount(amount => amount < 2))
        {
            // TODO: Handle loop.
        }
        return sum;
    }
}
