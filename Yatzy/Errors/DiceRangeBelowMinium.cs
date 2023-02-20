namespace Yatzy.Errors;
/// <summary>
/// Thrown when the minimum is too small.
/// </summary>
public class DiceRangeBelowMinium : Exception
{
    /// <summary>
    /// The minimum supported.
    /// </summary>
    public int SupportedMinimum { get; init; }
    /// <summary>
    /// The current minimum.
    /// </summary>
    public int CurrentMinimum { get; init; }
    /// <inheritdoc/>
    public DiceRangeBelowMinium()
    {
    }
    /// <inheritdoc/>
    public DiceRangeBelowMinium(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public DiceRangeBelowMinium(string message, Exception innerException) : base(message, innerException)
    {
    }
}
