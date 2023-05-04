using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories.SameValueRuleFactories;
/// <summary>
/// Represents a <see cref="SameValueRuleFactory{TDice}"/> which creates a <see cref="SameValueRule{TDice}"/> with the value of 5.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="SameValueRuleFactory{TDice}" path="/typeparam"/></typeparam>
public sealed class Fives<TDice> : SameValueRuleFactory<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    protected override string Identifier { get; } = nameof(Fives<TDice>);
    /// <inheritdoc/>
    protected override int Face { get; } = 5;
    /// <summary>
    /// Constructs a new instance of <see cref="Fives{TDice}"/>.
    /// </summary>
    /// <param name="pointsCalculator"><inheritdoc cref="SameValueRuleFactory{TDice}.SameValueRuleFactory(IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
    public Fives(IPointsCalculator? pointsCalculator) : base(pointsCalculator)
    {
    }
}
