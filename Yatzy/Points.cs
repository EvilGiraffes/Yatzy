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
    /// Whether the amount has been calculated.
    /// </summary>
    public bool Recieved { get; private init; } = true;
    /// <summary>
    /// An instance of points where it has not been recieved. Used when you wont give points.
    /// </summary>
    public static readonly Points NotRecieved = new()
    {
        Amount = 0,
        Recieved = false
    };
    /// <summary>
    /// The absolute minimum amount of points allowed to give, if it is less than this it means the amount hasn't been calculated.
    /// </summary>
    public const int MinimumPoints = 1;
    /// <summary>
    /// Constructs a new instance of points.
    /// </summary>
    /// <param name="points">The amount to be given, cannot be under the <see cref="MinimumPoints"/>.</param>
    /// <exception cref="PointsOutOfRange">Thrown if the value is below <see cref="MinimumPoints"/></exception>
    public Points(int points) : this()
    {
        if (points < MinimumPoints)
            throw new PointsOutOfRange($"Points can't be under {MinimumPoints}, the points provided is {points}.");
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
}
