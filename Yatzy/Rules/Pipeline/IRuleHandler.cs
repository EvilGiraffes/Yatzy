using Yatzy.Dices;

namespace Yatzy.Rules.Pipeline;
/// <summary>
/// Represents a layer between the <see cref="IRule{TDice}"/> method calls.
/// </summary>
/// <typeparam name="TDice">The dice the given rules are applicable for.</typeparam>
public interface IRuleHandler<TDice>
    where TDice : IDice
{
    /// <summary>
    /// Handles the calling of <see cref="IRule{TDice}.IsApplicable(IReadOnlyList{TDice})"/> method call.
    /// </summary>
    /// <param name="rule">The rule to handle.</param>
    /// <param name="hand"><inheritdoc cref="IRule{TDice}.IsApplicable(IReadOnlyList{TDice})" path="/param[@name='hand']"/></param>
    /// <returns><inheritdoc cref="IRule{TDice}.IsApplicable(IReadOnlyList{TDice})" path="/returns"/></returns>
    bool IsApplicable(IRule<TDice> rule, IReadOnlyList<TDice> hand);
    /// <summary>
    /// Handles the calling of <see cref="IRule{TDice}.CalculatePoints(IReadOnlyList{TDice})"/> method call.
    /// </summary>
    /// <param name="rule"><inheritdoc cref="IsApplicable(IRule{TDice}, IReadOnlyList{TDice})" path="/param[@name='rule']"/></param>
    /// <param name="hand"><inheritdoc cref="IRule{TDice}.CalculatePoints(IReadOnlyList{TDice})" path="/param[@name='hand']"/></param>
    /// <returns><inheritdoc cref="IRule{TDice}.CalculatePoints(IReadOnlyList{TDice})" path="/returns"/></returns>
    Points CalculatePoints(IRule<TDice> rule, IReadOnlyList<TDice> hand);
}
