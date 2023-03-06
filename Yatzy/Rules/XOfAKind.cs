using Serilog;

using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Logging;
using Yatzy.PointsCalculators;

namespace Yatzy.Rules;
// TESTME: This will need testing.
/// <summary>
/// Represents an <see cref="IRule{TDice}"/> where there is an X amount of kind.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class XOfAKind<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type LogType
        => typeof(XOfAKind<TDice>);
    /// <inheritdoc/>
    public string Name { get; }
    /// <summary>
    /// The absolute minimum count allowed.
    /// </summary>
    public const int MinimumCount = 1;
    /// <summary>
    /// The absolute maximum count allowed.
    /// </summary>
    public const int MaximumCount = int.MaxValue;
    readonly ILogger logger;
    readonly IPointsCalculator pointsCalculator;
    readonly Func<ICounter<int>> counterFactory;
    readonly int ofAKind;
    /// <summary>
    /// Constructs a new instance of <see cref="XOfAKind{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="pointsCalculator">The strategy to calculate the points based on.</param>
    /// <param name="counterFactory">The factory to create a counter.</param>
    /// <param name="ofAKind">The amount of similar values that has to be equal.</param>
    /// <exception cref="XOfAKindOutOfRange">Throw when the count is in the incorrect range.</exception>
    public XOfAKind(ILogger logger, IPointsCalculator pointsCalculator, Func<ICounter<int>> counterFactory, int ofAKind)
    {
        this.logger = logger.ForType<XOfAKind<TDice>>();
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        if (ofAKind is < MinimumCount or > MaximumCount)
        {
            this.logger.Error(
                "Construction failed. The count is out of range. The count given is {Count}, the range it is expected to be within is {MinimumCount}-{MaximumCount}",
                ofAKind, MinimumCount, MaximumCount);
            throw new XOfAKindOutOfRange()
            {
                Given = ofAKind,
                Minimum = MinimumCount,
                Maximum = MaximumCount
            };
        }
        this.ofAKind = ofAKind;
        Name = $"{ofAKind}OfAKind";
    }
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points result = Points.Empty;
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        foreach (Count<int> count in counter.FilterByAmount(amount => amount >= ofAKind))
        {
            Points recieved = pointsCalculator.Calculate(count.Item) * ofAKind;
            result = Points.Max(result, recieved);
        }
        return result;
    }
}
