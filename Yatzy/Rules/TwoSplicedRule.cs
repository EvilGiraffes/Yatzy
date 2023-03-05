using Serilog;

using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Extentions;
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
    /// <inheritdoc/>
    public string Name { get; }
    readonly ILogger logger;
    readonly ISpliceStrategy splicer;
    readonly IPointsCalculator pointsCalculator;
    readonly Func<ICounter<int>> counterFactory;
    readonly record struct Faces(int Max, int Min);
    /// <summary>
    /// Constructs a new instance of <see cref="TwoSplicedRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="identifier">What to identify this rule as.</param>
    /// <param name="splicer">The splicing strategy to use in this rule.</param>
    /// <param name="pointsCalculator">The calculator defined to calculate the points.</param>
    /// <param name="counterFactory">A factory to create counters.</param>
    public TwoSplicedRule(ILogger logger, string identifier, ISpliceStrategy splicer, IPointsCalculator pointsCalculator, Func<ICounter<int>> counterFactory)
    {
        this.logger = logger.ForType<TwoSplicedRule<TDice>>();
        Name = identifier;
        this.splicer = splicer;
        this.pointsCalculator = pointsCalculator;
        this.counterFactory = counterFactory;
    }


    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyList<TDice> hand)
    {
        if (hand.IsEmpty())
            return Points.Empty;
        ICounter<int> counter = counterFactory();
        counter.Count(hand.Select(dice => dice.Face));
        Bounds bounds = splicer.Splice(hand.Count);
        Faces faces = GetMaxAndMinFace(counter, bounds);
        return HandlePoints(faces, bounds);
    }
    Faces GetMaxAndMinFace(ICounter<int> counter, Bounds bounds)
    {
        int maxHigherBound = int.MinValue;
        int maxLowerBound = int.MinValue;
        foreach ((int face, int count) in counter.FilterByAmount(amount => amount >= bounds.Low))
        {
            if (count < bounds.High)
            {
                maxLowerBound = Math.Max(face, maxLowerBound);
                continue;
            }
            if (face < maxHigherBound)
                continue;
            maxLowerBound = Math.Max(maxHigherBound, maxLowerBound);
            maxHigherBound = face;
        }
        logger.Debug(
            "Calculated the max and min face from {Counter}. From the bound found the maximum face for the {MaxBound} count to be {MaxCount}, and from the minimum face for the {MinBound} count to be {MinCount}.",
            counter, bounds.High, maxHigherBound, bounds.Low, maxLowerBound);
        return new(maxHigherBound, maxLowerBound);
    }
    Points HandlePoints(Faces faces, Bounds bounds)
    {
        if (faces.Max < 1 || faces.Min < 1)
            return Points.Empty;
        return pointsCalculator.Calculate(faces.Max) * bounds.High + pointsCalculator.Calculate(faces.Min) * bounds.Low;
    }
}
