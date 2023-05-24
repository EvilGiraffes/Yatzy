using Serilog;

using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules.Factories.SameValueRuleFactories;
/// <summary>
/// Represents a factory for <see cref="SameValueRule{TDice}"/>.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleFactory{TDice}" path="/typeparam[@name='TDice']"/></typeparam>
public abstract class SameValueRuleFactory<TDice> : IRuleFactory<TDice>
    where TDice : IDice
{
    /// <summary>
    /// What name this rule has, or which identity it should take.
    /// </summary>
    protected abstract string Identifier { get; }
    /// <summary>
    /// Which face this rule represents.
    /// </summary>
    protected abstract int Face { get; }
    readonly ILogger logger;
    readonly IPointsCalculator pointsCalculator;
    /// <summary>
    /// Creates the <see cref="SameValueRule{TDice}"/> with the new values.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="pointsCalculator">
    /// <para>The calculator to be used to calculate points.</para>
    /// <para>Defaults to <see cref="FaceBasedCalculation"/>.</para>
    /// </param>
    public SameValueRuleFactory(ILogger logger, IPointsCalculator? pointsCalculator)
    {
        this.logger = logger;
        this.pointsCalculator = pointsCalculator ?? new FaceBasedCalculation();
    }
    /// <inheritdoc/>
    public IRule<TDice> Create(ILogger _)
        => new SameValueRule<TDice>(logger, Identifier, Face, pointsCalculator);
}
