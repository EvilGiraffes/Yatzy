using Serilog;

using Yatzy.Logging;

namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents a <see cref="ISpliceStrategy"/> to splice it as per a full house.
/// </summary>
/// <remarks>
/// A full house favors splice in the middle or splice left side being smaller if uneven.
/// </remarks>
public sealed class FullHouse : SpliceTemplate
{
    /// <summary>.
    /// Creates a new instance of <see cref="FullHouse"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="SpliceTemplate(ILogger)" path="/param[@name='logger']"/></param>
    public FullHouse(ILogger logger) : base(logger.ForType<FullHouse>())
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
            return new((int) splice, (int) splice);
        int lowerBound = (int) Math.Floor(splice);
        int higherBound = (int) Math.Ceiling(splice);
        return new(lowerBound, higherBound);
    }
}
