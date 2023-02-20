using Serilog;

using Yatzy.Dices;
using Yatzy.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// Represents a full house rule.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class FullHouse<TDice> : IRule<TDice>
    where TDice : IDice
{
    readonly ILogger logger;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Constructs a new instance of <see cref="FullHouse{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="pointsCalculator">The calculator defined to calculate the points.</param>
    public FullHouse(ILogger logger, IPointsCalculator pointsCalculator)
    {
        this.logger = logger;
        this.pointsCalculator = pointsCalculator;
    }
    // TODO: Implement.
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        Bounds bounds = CalculateBounds(hand.Count);
        throw new NotImplementedException();
    }
    static Bounds CalculateBounds(int count)
    {
        if (count % 2 == 0)
            return new()
            {
                Low = count / 2 - 1,
                High = count / 2 + 1,
            };
        double midPoint = count / 2;
        return new()
        {
            Low = (int) Math.Floor(midPoint),
            High = (int) Math.Ceiling(midPoint)
        };
    }
    readonly ref struct Bounds
    {
        public int Low { get; init; }
        public int High { get; init; }
    }
}
