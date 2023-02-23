using Serilog;

using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Logging;
using Yatzy.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Rules;
// TESTME: Needs testing.
/// <summary>
/// Represents a rule that has two splices.
/// </summary>
/// <remarks>
/// An example of a double spliced rule is Full House which in regular yatzy would be spliced by 2 + 3.
/// </remarks>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class TwoSplicedRule<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public Type LogType
        => typeof(TwoSplicedRule<TDice>);
    readonly ILogger logger;
    readonly ISpliceStrategy splicer;
    readonly IPointsCalculator pointsCalculator;
    readonly Func<ICounter<int>> counterFactory;
    /// <summary>
    /// Constructs a new instance of <see cref="TwoSplicedRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="splicer">The splicing strategy to use in this rule.</param>
    /// <param name="pointsCalculator">The calculator defined to calculate the points.</param>
    /// <param name="counterFactory">A factory to create counters.</param>
    public TwoSplicedRule(ILogger logger, ISpliceStrategy splicer, IPointsCalculator pointsCalculator, Func<ICounter<int>> counterFactory)
    {
        this.logger = logger.ForType<TwoSplicedRule<TDice>>();
        this.splicer = splicer;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
    }


    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        Bounds bounds = splicer.Splice(hand.Count);
        (int maxFace, int minFace) = GetMaxAndMinFace(counter, bounds);
        Points result = HandlePoints(maxFace, minFace, bounds);
        return result;
    }
    (int, int) GetMaxAndMinFace(ICounter<int> counter, Bounds bounds)
    {
        int maxHigherBound = int.MinValue;
        int maxLowerBound = int.MinValue;
        foreach ((int face, int count) in counter)
        {
            if (count >= bounds.High)
            {
                if (face < maxHigherBound)
                    continue;
                maxLowerBound = Math.Max(maxHigherBound, maxLowerBound);
                maxHigherBound = face;
                continue;
            }
            if (count < bounds.Low)
                continue;
            maxLowerBound = Math.Max(face, maxLowerBound);
        }
        logger.Debug(
            "Calculated the max and min face from {Counter}. From the bound found the maximum face for the {MaxBound} count to be {MaxCount}, and from the minimum face for the {MinBound} count to be {MinCount}.",
            counter, bounds.High, maxHigherBound, bounds.Low, maxLowerBound);
        return (maxHigherBound, maxLowerBound);
    }
    Points HandlePoints(int maxFace, int minFace, Bounds bounds)
    {
        if (maxFace < 1 || minFace < 1)
            return Points.Empty;
        return pointsCalculator.Calculate(maxFace) * bounds.High + pointsCalculator.Calculate(minFace) * bounds.High;
    }
}
