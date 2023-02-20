namespace Yatzy.Errors;
/// <summary>
/// An exception thrown when the Points couldnt be converted.
/// </summary>
public class PointsCastException : Exception
{
    /// <summary>
    /// The value it was trying to convert from.
    /// </summary>
    public int From { get; init; }
    /// <inheritdoc/>
    public PointsCastException()
    {
    }
    /// <inheritdoc/>
    public PointsCastException(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public PointsCastException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
