using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
// TODO: Builder.
/// <summary>
/// Represents an <see cref="IRule{TDice}"/> where there is an X amount of kind.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class XOfAKind<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public string Name { get; }
    /// <summary>
    /// The absolute inclusive minimum count allowed.
    /// </summary>
    public const int MinimumCount = 1;
    /// <summary>
    /// The absolute inclusive maximum count allowed.
    /// </summary>
    public const int MaximumCount = int.MaxValue;
    /// <summary>
    /// Transforms X into a <see cref="string"/> representation.
    /// </summary>
    /// <param name="x">The integrer to transform.</param>
    /// <returns>A new <see cref="string"/> representing <paramref name="x"/></returns>
    public delegate string XTransform(int x);
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int> counterFactory;
    readonly int x;
    /// <summary>
    /// Constructs a new instance of <see cref="XOfAKind{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="x">The amount of similar values that has to be equal.</param>
    /// <param name="xTransform">The transformation for <paramref name="x"/> to name the instance with <see cref="XOfAKind{TDice}.Name"/>.</param>
    /// <param name="pointsCalculator">The strategy to calculate the points based on.</param>
    /// <exception cref="XOfAKindOutOfRange">Throw when the count is in the incorrect range.</exception>
    /// <param name="counterFactory">The factory to create a counter.</param>
    internal XOfAKind(ILogger logger, int x, XTransform xTransform, IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory)
    {
        ILogger constructorLogger = logger.ForType<XOfAKind<TDice>>();
        VerifyX(
            x,
            x => constructorLogger.Error(
            "Construction failed. The count is out of range. The count given is {Count}, the range it is expected to be within is {MinimumCount}-{MaximumCount}",
            x, MinimumCount, MaximumCount));
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        Name = $"{xTransform(x)}OfAKind";
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points result = Points.Empty;
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        foreach (int item in counter
            .FilterByAmount(amount => amount >= x)
            .Select(count => count.Item))
        {
            Points recieved = pointsCalculator.Calculate(item) * x;
            result = Points.Max(result, recieved);
        }
        return result;
    }
    /// <summary>
    /// Gets the builder to create an instance <see cref="XOfAKind{TDice}"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="XOfAKind(ILogger, int, XTransform, IPointsCalculator, CounterFactory{int})" path="/param[@name='logger']"/></param>
    /// <returns>A new instance of <see cref="XOfAKindBuilder{TDice}"/> to create an instance of <see cref="XOfAKind{TDice}"/>.</returns>
    public static XOfAKindBuilder<TDice> Builder(ILogger logger)
        => new(logger);
    static void VerifyX(int x, Action<int> failCallback)
    {
        if (x is not < MinimumCount and not > MaximumCount)
            return;
        failCallback(x);
        throw new XOfAKindOutOfRange()
        {
            Given = x,
            Minimum = MinimumCount,
            Maximum = MaximumCount
        };
    }
}
