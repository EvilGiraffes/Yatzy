using Yatzy.Dices;

namespace Yatzy.DiceStates;
/// <summary>
/// Represents a dice rolling state.
/// </summary>
public interface IDiceState
{
    /// <summary>
    /// Create a roll based on its own implementation.
    /// </summary>
    /// <param name="context">The caller of this method.</param>
    /// <returns>Value dependent on its on implementation.</returns>
    int Roll(IDice context, DiceRange range);
}
