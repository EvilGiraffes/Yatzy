namespace Yatzy.Errors;
/// <summary>
/// Represents an exception that will be thrown if the points is out of the specified range.
/// </summary>
public class PointsOutOfRange : Exception
{
    /// <summary>
    /// The minimum points that is valid.
    /// </summary>
    public int Minimum { get; init; }
    /// <summary>
    /// The amount of points that was recived.
    /// </summary>
    public int Received { get; init; }
    /// <summary>
    /// Represents the difference between the recieved and the range.
    /// </summary>
    /// <value>Is in the negatives if it is below minimum and in the positive if not.</value>
    public int Difference
    {
        get
        {
            if (Received < Minimum)
                return Received - Minimum;
            return 0;
        }
    }
    /// <inheritdoc cref="Exception()"/>
    public PointsOutOfRange()
    {
    }
    /// <inheritdoc cref="Exception(string?)"/>
    public PointsOutOfRange(string? message) : base(message)
    {
    }
    /// <inheritdoc cref="Exception(string?, Exception?)"/>
    public PointsOutOfRange(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
