using System.Diagnostics;

using Serilog;

using Yatzy.DiceStates;
using Yatzy.Errors;
using Yatzy.Utils;

namespace Yatzy.Dices;
/// <summary>
/// Represents a dice that has six faces.
/// </summary>
public sealed class SixFacedDice : IDice
{
    /// <inheritdoc/>
    /// <exception cref="DiceFaceOutOfRange">Thrown if the face is out of the specified range.</exception>
    public int Face
    {
        get => _face;
        private set
        {
            DiceFaceOutOfRange.Guard(logger, value, Range);
            _face = value;
        }
    }
    /// <summary>
    /// Represents the range this dice is under, the minimum range it has is 1 and the maximum is 6, inclusive values.
    /// </summary>
    public static readonly DiceRange Range = new()
    {
        MinimumFace = 1,
        MaximumFace = 6
    };
    /// <inheritdoc/>
    public IDiceState State { get; set; }
    readonly ILogger logger;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    int _face;
    /// <summary>
    /// Constructs a new instance of a sixfaced dice.
    /// </summary>
    /// <param name="logger">The logger used throughout the application.</param>
    /// <param name="startState">The state the dice should start in.</param>
    /// <param name="startFace">The face the dice should start in, default is 1</param>
    public SixFacedDice(ILogger logger, IDiceState startState, int startFace = 1)
    {
        this.logger = logger.ForType<SixFacedDice>();
        State = startState;
        Face = startFace;
    }
    /// <inheritdoc/>
    public void Roll()
        => Face = State.Roll(this, Range);
}
