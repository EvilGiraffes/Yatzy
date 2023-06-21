using Serilog;

using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Logging;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
public sealed class XPairsBuilder<TDice> : BuilderTemplate<XPairs<TDice>>
    where TDice : IDice
{
    readonly ILogger logger;
    int? x = default;
    StringTransform<int>? xTransform = default;
    IPointsCalculator pointsCalculator = default!;
    CounterFactory<int> counterFactory = default!;
    public XPairsBuilder(ILogger logger) : base(logger.ForType<XPairsBuilder<TDice>>())
    {
        this.logger = logger;
    }
    public XPairsBuilder<TDice> X(int x)
    {
        this.x = x;
        return this;
    }
    public XPairsBuilder<TDice> XTransform(StringTransform<int> xTransform)
    {
        this.xTransform = xTransform;
        return this;
    }
    public XPairsBuilder<TDice> PointsCalculator(IPointsCalculator pointsCalculator)
    {
        this.pointsCalculator = pointsCalculator;
        return this;
    }
    public XPairsBuilder<TDice> CounterFactory(CounterFactory<int> counterFactory)
    {
        this.counterFactory = counterFactory;
        return this;
    }
    /// <inheritdoc/>
    protected override IEnumerable<Member> RequiredMemberObjects()
    {
        yield return new(x);
        yield return new(pointsCalculator);
        yield return new(counterFactory);
    }
    /// <inheritdoc/>
    protected override XPairs<TDice> Create()
    {
        xTransform ??= x => x.ToString();
        return new(logger, (int) x!, xTransform, pointsCalculator, counterFactory);
    }
}
