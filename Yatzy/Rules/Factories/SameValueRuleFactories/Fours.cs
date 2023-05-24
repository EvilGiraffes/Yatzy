using Serilog;

using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories.SameValueRuleFactories;
/// <summary>
/// Represents a <see cref="SameValueRuleFactory{TDice}"/> which creates a <see cref="SameValueRule{TDice}"/> with the value of 4.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="SameValueRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class Fours<TDice> : SameValueRuleFactory<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    protected override string Identifier { get; } = nameof(Fours<TDice>);
    /// <inheritdoc/>
    protected override int Face { get; } = 4;
    /// <summary>
    /// Constructs a new instance of <see cref="Fours{TDice}"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="SameValueRuleFactory{TDice}.SameValueRuleFactory(ILogger, IPointsCalculator)" path="/param[@name='logger']"/></param>
    /// <param name="pointsCalculator"><inheritdoc cref="SameValueRuleFactory{TDice}.SameValueRuleFactory(Serilog.ILogger, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
    public Fours(ILogger logger, IPointsCalculator? pointsCalculator = null) : base(logger, pointsCalculator)
    {
    }

}
