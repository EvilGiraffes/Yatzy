using System.Text;

using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Extentions;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Rules;
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
    public string Name { get; }
    readonly ILogger logger;
    readonly ISpliceStrategy splicer;
    readonly IPointsCalculator pointsCalculator;
    readonly CounterFactory<int> counterFactory;
    readonly record struct Faces(int Max, int Min);
    /// <summary>
    /// Constructs a new instance of <see cref="TwoSplicedRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="identifier">What to identify this rule as.</param>
    /// <param name="splicer">The splicing strategy to use in this rule.</param>
    /// <param name="pointsCalculator">The calculator defined to calculate the points.</param>
    /// <param name="counterFactory">A factory to create counters.</param>
    internal TwoSplicedRule(ILogger logger, string identifier, ISpliceStrategy splicer, IPointsCalculator pointsCalculator, CounterFactory<int> counterFactory)
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
    /// <summary>
    /// Gets the builder to create an instance <see cref="TwoSplicedRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">
    /// <inheritdoc 
    /// cref="TwoSplicedRule(ILogger, string, ISpliceStrategy, IPointsCalculator, CounterFactory{int})" 
    /// path="/param[@name='logger']"/>
    /// </param>
    /// <returns>A new <see cref="TwoSplicedRuleBuilder{TDice}"/>.</returns>
    public static TwoSplicedRuleBuilder<TDice> Builder(ILogger logger)
        => new(logger);
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
        StringBuilder builder = new();
        builder
            .Append("Calculated the max and min face from {Counter}. ")
            .Append("From the bound found the maximum face for the {MaxBound} count to be {MaxCount}, ")
            .Append("and from the minimum face for the {MinBound} count to be {MinCount}.")
            .ToString(
            template => logger.Debug(template, counter, bounds.High, maxHigherBound, bounds.Low, maxLowerBound));
        return new(maxHigherBound, maxLowerBound);
    }
    Points HandlePoints(Faces faces, Bounds bounds)
    {
        if (faces.Max < 1 || faces.Min < 1)
            return Points.Empty;
        return pointsCalculator.Calculate(faces.Max) * bounds.High + pointsCalculator.Calculate(faces.Min) * bounds.Low;
    }
}
