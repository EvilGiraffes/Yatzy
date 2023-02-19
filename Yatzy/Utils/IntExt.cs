namespace Yatzy.Utils;
// TESTME: Needs testing.
/// <summary>
/// Extentions for the type of <see cref="int"/>.
/// </summary>
public static class IntExt
{
    /// <summary>
    /// Checks if the value is within the specified dice range.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="range">The range to check against.</param>
    /// <returns><see langword="true"/> if it is in the range, <see langword="false"/> if it isn't.</returns>
    public static bool InRangeOf(this int value, DiceRange range)
        => value >= range.MinimumFace
        && value <= range.MaximumFace;
}
