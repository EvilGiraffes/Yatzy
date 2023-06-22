using Yatzy.Dices;

namespace Yatzy.Rules.Pipeline;
/// <summary>
/// Represents a <see cref="IRuleHandler{TDice}"/> which executes the methods directly.
/// </summary>
/// <typeparam name="TDice"><inheritdoc cref="IRuleHandler{TDice}" path="/typeparam"/></typeparam>
public sealed class ExecutionHandler<TDice> : IRuleHandler<TDice>
    where TDice : IDice
{
    /// <inheritdoc/>
    public bool IsApplicable(IRule<TDice> rule, IReadOnlyCollection<TDice> hand)
        => rule.IsApplicable(hand);
    /// <inheritdoc/>
    public Points CalculatePoints(IRule<TDice> rule, IReadOnlyCollection<TDice> hand)
        => rule.CalculatePoints(hand);
}
