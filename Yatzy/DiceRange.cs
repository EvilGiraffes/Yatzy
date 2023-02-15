using System.Diagnostics;

using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents the range for a dice.
/// </summary>
public readonly record struct DiceRange
{
    /// <summary>
    /// The inclusive minimum face it can have.
    /// </summary>
    /// <exception cref="DiceRangeBelowMinium">Thrown if the minimum bound is under <see cref="MinimumLowerBound"/>.</exception>
    public readonly int MinimumFace
    {
        get => _minimumFace;
        init
        {
            if (value < MinimumLowerBound)
                throw new DiceRangeBelowMinium("Minimum value is too small.")
                {
                    SupportedMinimum = MinimumLowerBound,
                    CurrentMinimum = value
                };
            _minimumFace = value;
        }
    }
    /// <summary>
    /// The inclusive maximum face it can have.
    /// </summary>
    public readonly int MaximumFace { get; init; }
    /// <summary>
    /// The lowest number the <see cref="MinimumFace"/> can be.
    /// </summary>
    public const int MinimumLowerBound = 1;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    readonly int _minimumFace = MinimumLowerBound;

    /// <summary>
    /// Constructs a new instance of a dice range.
    /// </summary>
    /// <param name="minimumFace"><inheritdoc cref="MinimumFace" path="/summary"/></param>
    /// <param name="maximumFace"><inheritdoc cref="MaximumFace" path="/summary"/></param>
    /// <exception cref="DiceRangeBelowMinium"><inheritdoc cref="MinimumFace" path="/exception"/></exception>
    public DiceRange(int minimumFace, int maximumFace) : this()
    {
        MinimumFace = minimumFace;
        MaximumFace = maximumFace;
    }
    /// <summary>
    /// Deconstructs the range into just the integral values.
    /// </summary>
    /// <param name="minimumFace">The minimum face contained in this range.</param>
    /// <param name="maximumFace">The maximum face contained in this range.</param>
    public void Deconstruct(out int minimumFace, out int maximumFace)
    {
        minimumFace = MinimumFace;
        maximumFace = MaximumFace;
    }
    /// <summary>
    /// Checks if this range is inside the boundaries of the other range.
    /// </summary>
    /// <param name="other">The other range to check if this is in the bounds of.</param>
    /// <returns><see langword="true"/> if this range is inside the other range, <see langword="false"/> if not.</returns>
    public bool InRangeOf(DiceRange other)
        => MinimumFace <= other.MinimumFace
        && MaximumFace >= other.MaximumFace;
}
