namespace Yatzy.Dices.States;
/// <summary>
/// Represents a dice rolling state.
/// </summary>
public interface IDiceState
{
    /// <summary>
    /// Create a roll based on its own implementation.
    /// </summary>
    /// <param name="context">The caller of this method.</param>
    /// <param name="range">The range this dice should roll within.</param>
    /// <returns>Value dependent on its on implementation.</returns>
    int Roll(IDice context, DiceRange range);
}
