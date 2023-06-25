using Serilog;

using Yatzy.Dices;

namespace Yatzy.Rules;
// TESTME: Requires testing.
/// <summary>
/// Represents an <see cref="IRule{TDice}"/> which checks if the values are in a sequence within a given count.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRule{TDice}" path="/typeparam"/></typeparam>
public sealed class Straight<TDice> : IRule<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public string Name { get; }
    readonly ILogger logger;
    readonly int count;
    readonly Points points;
    /// <summary>
    /// Constructs a new <see cref="Straight{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="prefix">The prefix name to the straight.</param>
    /// <param name="count">The count this straight should expect the sequence to be.</param>
    /// <param name="points">The points given when the rule is successful.</param>
    public Straight(ILogger logger, string prefix, int count, Points points)
    {
        Name = $"{prefix}{nameof(Straight<TDice>)}";
        this.logger = logger;
        this.count = count;
        this.points = points;
    }
    /// <inheritdoc/>
    public bool IsApplicable(IReadOnlyCollection<TDice> hand)
        => hand.Count >= count;
    /// <inheritdoc/>
    public Points CalculatePoints(IReadOnlyCollection<TDice> hand)
    {
        SortedSet<int> sortedHand = new(hand.Select(dice => dice.Face));
        int currentCount = 0;
        int lastValueCache = int.MinValue;
        foreach (int face in sortedHand)
        {
            int previousFace = lastValueCache;
            lastValueCache = face;
            if (face - 1 != previousFace)
            {
                logger.Verbose("The current face {Face} is not in sequence with the previous face {PreviousFace}.", face, previousFace);
                currentCount = 0;
                continue;
            }
            currentCount++;
            if (currentCount >= count)
                return points;
            logger.Verbose("The current count {CurrentCount} is not greater or equal to the count required {Count} yet.", currentCount, count);
        }
        return Points.Empty;
    }
}
