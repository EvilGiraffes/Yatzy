using Serilog;

using Yatzy.Logging;

namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents a <see cref="ISpliceStrategy"/> to splice it as per a full house.
/// </summary>
/// <remarks>
/// A full house favors splice in the middle or splice left side being smaller if uneven.
/// </remarks>
public sealed class FullHouseSplicer : SpliceTemplate
{
    /// <summary>.
    /// Creates a new instance of <see cref="FullHouseSplicer"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="SpliceTemplate(ILogger)" path="/param[@name='logger']"/></param>
    public FullHouseSplicer(ILogger logger) : base(logger.ForType<FullHouseSplicer>())
    {
    }
    /// <inheritdoc/>
    protected override SpliceContext DivideCount(double count)
        => new()
        {
            Splice = count / 2,
            Max = count
        };
    /// <inheritdoc/>
    protected override Bounds HandleSplicing(SpliceContext context)
    {
        double splice = context.Splice;
        if (context.IsEven)
        {
            Logger.Verbose("The splice was even, it will splice it in half.");
            return new((int) splice, (int) splice);
        }
        int lowerBound = (int) Math.Floor(splice);
        int higherBound = (int) Math.Ceiling(splice);
        Logger.Verbose("The splice was uneven, it will lean more heavy towards the lowerbound.");
        return new(lowerBound, higherBound);
    }
}
