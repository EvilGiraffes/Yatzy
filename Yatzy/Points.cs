using System.Diagnostics.CodeAnalysis;

using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents points recieved.
/// </summary>
public readonly struct Points : IEquatable<Points>
{
    /// <summary>
    /// The amount of points that has been given.
    /// </summary>
    public int Amount { get; } = MinimumPoints;
    /// <summary>
    /// Whether there is more than 0 points.
    /// </summary>
    public bool HasPoints
        => Amount > MinimumPoints;
    /// <summary>
    /// An instance of points where it has not been recieved. Used when you wont give points.
    /// </summary>
    /// <value>Will always be the same value, which would be the same as passing <see cref="MinimumPoints"/> to the constructor.</value>
    public static Points Empty { get; } = new(MinimumPoints);
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
        if (points is < MinimumPoints or > MaximumPoints)
            throw new PointsOutOfRange
            {
                Maximum = MaximumPoints,
                Minimum = MinimumPoints,
                Received = points
            };
        Amount = points;
    }
    /// <inheritdoc/>
    public bool Equals(Points other)
    {
        if (!HasPoints && !other.HasPoints)
            return true;
        return Amount == other.Amount;
    }
    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Points points && Equals(points);
    /// <inheritdoc/>
    public override int GetHashCode()
        => HasPoints ? Amount ^ Amount >> 32 : MinimumPoints ^ MinimumPoints >> 32;
    /// <inheritdoc/>
    public override string ToString()
        => HasPoints ? $"{Amount} {nameof(Points)}" : $"No {nameof(Points)}";

    /// <summary>
    /// Will cast from an <see cref="int"/> to a new <see cref="Points"/>.
    /// </summary>
    /// <param name="points">The value to cast from.</param>
    /// <exception cref="PointsOutOfRange"><inheritdoc cref="Points(int)" path="/exception"/></exception>
    /// <exception cref="PointsCastException">Thrown if the casting fails.</exception>
    public static implicit operator Points(int points)
    {
        try
        {
            return new Points(points);
        }
        catch (PointsOutOfRange outOfRange)
        {
            throw new PointsCastException($"Casting the points returned an exception.", outOfRange)
            {
                From = points
            };
        }
    }
    /// <summary>
    /// Adds to points together.
    /// </summary>
    /// <param name="left">The left point to add.</param>
    /// <param name="right">The right point to add.</param>
    /// <returns>A new point with the new result.</returns>
    public static Points operator +(Points left, Points right)
        => new(left.Amount + right.Amount);
    /// <summary>
    /// Multiplies the points together.
    /// </summary>
    /// <param name="left">The left point to multiply.</param>
    /// <param name="right">The right point to multiply.</param>
    /// <returns>A new <see cref="Points"/> after being multiplied.</returns>
    public static Points operator *(Points left, Points right)
        => new(left.Amount * right.Amount);
    /// <summary>
    /// Checks for the equality of the points.
    /// </summary>
    /// <param name="left">The left most point to check.</param>
    /// <param name="right">The right most point to check.</param>
    /// <returns><see langword="true"/> if they are equal, <see langword="false"/> if not.</returns>
    public static bool operator ==(Points left, Points right)
        => left.Equals(right);
    /// <summary>
    /// Checks for inequality of the points.
    /// </summary>
    /// <param name="left"><inheritdoc cref="operator ==(Points, Points)" path="/param[@name='left']"/></param>
    /// <param name="right"><inheritdoc cref="operator ==(Points, Points)" path="/param[@name='right']"/></param>
    /// <returns><see langword="true"/> if they are not equal, <see langword="false"/> if they are equal.</returns>
    public static bool operator !=(Points left, Points right)
        => !(left == right);
}
