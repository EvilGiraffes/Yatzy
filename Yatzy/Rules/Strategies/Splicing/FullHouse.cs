using Serilog;

using Yatzy.Errors;
using Yatzy.Logging;

namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents a <see cref="ISpliceStrategy"/> to splice it as per a full house.
/// </summary>
public sealed class FullHouse : ISpliceStrategy
{
    readonly ILogger logger;
    const int MinimumCount = 2;
    /// <summary>.
    /// Creates a new instance of <see cref="FullHouse"/>
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    public FullHouse(ILogger logger)
    {
        this.logger = logger.ForType<FullHouse>();
    }
    /// <inheritdoc/>
    public Bounds Splice(int count)
    {
        if (count < MinimumCount)
        {
            logger.Error("Count {Count} is below minimum {MinimumCount}", count, MinimumCount);
            throw new InvalidSpliceOperation($"Count cannot be under {MinimumCount}.");
        }
        double splice = count / 2d;
        Bounds result = HandleSplicing(count, splice);
        logger.Debug("Splice was {Result}", result);
        return result;
    }
    static Bounds HandleSplicing(int count, double splice)
    {
        if (count % 2 == 0)
        {
            return new((int) splice, (int) splice);
        }
        int lowerBound = (int) Math.Floor(splice);
        int higherBound = (int) Math.Ceiling(splice);
        return new(lowerBound, higherBound);
    }
}
