using Yatzy.DiceStates;

namespace Yatzy.Dices;
/// <summary>
/// Represents a dice implementation.
/// </summary>
public interface IDice
{
    /// <summary>
    /// The current face of the dice.
    /// </summary>
    int Face { get; }
    /// <summary>
    /// The current state of the dice.
    /// </summary>
    IDiceState State { get; set; }
    /// <summary>
    /// <para>Will roll the dice according to the <see cref="IDiceState"/>.</para>
    /// <para>The roll will be stored in the <see cref="Face"/> property.</para>
    /// </summary>
    void Roll();
}
