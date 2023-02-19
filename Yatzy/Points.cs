using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents points recieved.
/// </summary>
public readonly record struct Points
{
    /// <summary>
    /// The amount of points that has been given.
    /// </summary>
    public int Amount { get; private init; } = MinimumPoints;
    /// <summary>
    /// Whether there is more than 0 points.
    /// </summary>
    public bool HasPoints
        => Amount > 0;
    /// <summary>
    /// An instance of points where it has not been recieved. Used when you wont give points.
    /// </summary>
    public static Points Empty
        => new(0);
    /// <summary>
    /// The absolute maximum amount of points allowed to give.
    /// </summary>
    public const int MaximumPoints = int.MaxValue;
    /// <summary>
    /// The absolute minimum amount of points that can be in this structure.
    /// </summary>
    public const int MinimumPoints = 0;
    /// <summary>
    /// Constructs a new instance of points.
    /// </summary>
    /// <param name="points">The amount to be given, cannot be under the <see cref="MinimumPoints"/>.</param>
    /// <exception cref="PointsOutOfRange">Thrown if the value is below <see cref="MinimumPoints"/></exception>
    public Points(int points) : this()
    {
        if (points < MinimumPoints || points > MaximumPoints)
            throw new PointsOutOfRange
            {
                Maximum = MaximumPoints,
                Minimum = MinimumPoints,
                Received = points
            };
        Amount = points;
    }
    /// <inheritdoc cref="Points(int)"/>
    public static implicit operator Points(int points)
    {
        try
        {
            return new Points(points);
        }
        catch (PointsOutOfRange outOfRange)
        {
            throw new InvalidCastException($"Casting the points returned an exception, which has the following message: {outOfRange.Message}", outOfRange);
        }
    }
    /// <summary>
    /// Increments the points.
    /// </summary>
    /// <param name="points">The points to increment.</param>
    /// <returns>A new <see cref="Points"/> which has its amount incremented.</returns>
    public static Points operator ++(Points points)
        => new(points.Amount + 1);
    /// <summary>
    /// Adds to points together.
    /// </summary>
    /// <param name="left">The left point to add.</param>
    /// <param name="right">The right point to add.</param>
    /// <returns>A new point with the new result.</returns>
    public static Points operator +(Points left, Points right)
        => new(left.Amount + right.Amount);
}
