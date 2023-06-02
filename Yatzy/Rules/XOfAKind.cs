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
    internal const int Minimum = 1;
    internal const int Maximum = int.MaxValue;
    readonly ILogger logger;
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
    /// <exception cref="XOutOfRange">Throw when the count is in the incorrect range.</exception>
    /// <param name="counterFactory">The factory to create a counter.</param>
    internal XOfAKind(ILogger logger, int x, StringTransform<int> xTransform, IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory)
    {
        this.logger = logger.ForType<XOfAKind<TDice>>();
        XOutOfRange.Guard(this.logger, x, Minimum, Maximum);
        this.x = x;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
        Name = $"{xTransform(x)}OfAKind";
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyList<TDice> hand)
        => hand.Count >= x;
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Points sum = Points.Empty;
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        foreach (int face in counter
            .FilterByAmount(amount => amount >= x)
            .Select(count => count.Item))
        {
            Points recieved = pointsCalculator.Calculate(face) * x;
            sum = Points.Max(sum, recieved);
            logger.Verbose("Current face is {Face}. The total points being calculated is {Recieved}. Current result is {Result}", face, recieved, sum);
        }
        return sum;
    }
    /// <summary>
    /// Gets the builder to create an instance <see cref="XOfAKind{TDice}"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="XOfAKind(ILogger, int, StringTransform{int}, IPointsCalculator, CounterFactory{int})" path="/param[@name='logger']"/></param>
    /// <returns>A new instance of <see cref="XOfAKindBuilder{TDice}"/> to create an instance of <see cref="XOfAKind{TDice}"/>.</returns>
    public static XOfAKindBuilder<TDice> Builder(ILogger logger)
        => new(logger);
}
