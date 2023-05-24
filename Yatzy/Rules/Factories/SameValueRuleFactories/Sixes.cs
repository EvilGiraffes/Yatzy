using Serilog;

using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories.SameValueRuleFactories;
/// <summary>
/// Represents a <see cref="SameValueRuleFactory{TDice}"/> which creates a <see cref="SameValueRule{TDice}"/> with the value of 6.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="SameValueRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class Sixes<TDice> : SameValueRuleFactory<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    protected override string Identifier { get; } = nameof(Sixes<TDice>);
    /// <inheritdoc/>
    protected override int Face { get; } = 6;
    /// <summary>
    /// Constructs a new instance of <see cref="Sixes{TDice}"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="SameValueRuleFactory{TDice}.SameValueRuleFactory(ILogger, IPointsCalculator)" path="/param[@name='logger']"/></param>
    /// <param name="pointsCalculator"><inheritdoc cref="SameValueRuleFactory{TDice}.SameValueRuleFactory(Serilog.ILogger, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
    public Sixes(ILogger logger, IPointsCalculator? pointsCalculator) : base(logger, pointsCalculator)
    {
    }
}
