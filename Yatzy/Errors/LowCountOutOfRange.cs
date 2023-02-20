namespace Yatzy.Errors;
/// <summary>
/// Thrown when the low count is larger or equal to the high count.
/// </summary>
public class LowCountOutOfRange : Exception
{
    /// <summary>
    /// The provided low count.
    /// </summary>
    public int LowCount { get; init; }
    /// <summary>
    /// The provided high count.
    /// </summary>
    public int HighCount { get; init; }
    /// <inheritdoc/>
    public LowCountOutOfRange()
    {
    }
    /// <inheritdoc/>
    public LowCountOutOfRange(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public LowCountOutOfRange(string message, Exception innerException) : base(message, innerException)
    {
    }
}
