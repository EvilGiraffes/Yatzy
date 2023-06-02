using System.Diagnostics.CodeAnalysis;

using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents points recieved.
/// </summary>
public readonly struct Points : IEquatable<Points>, IComparable<Points>
{
    /// <summary>
    /// Whether there is more than 0 points.
    /// </summary>
    public bool HasPoints
        => amount > uint.MinValue;
    /// <summary>
    /// An instance of points where it has not been recieved. Used when you wont give points.
    /// </summary>
    /// <value>Will always be the same value, which would be the same as passing 0 to the constructor.</value>
    public static Points Empty { get; } = new(uint.MinValue);
    readonly uint amount;
    Points(uint points) : this()
    {
        amount = points;
    }
    /// <inheritdoc/>
    public bool Equals(Points other)
    {
        if (!HasPoints && !other.HasPoints)
            return true;
        return amount == other.amount;
    }
    /// <inheritdoc/>
    public int CompareTo(Points other)
            => amount.CompareTo(other.amount);
    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Points points && Equals(points);
    /// <inheritdoc/>
    public override int GetHashCode()
    {
        uint hash = amount ^ amount >> 32;
        return hash.GetHashCode();
    }
    /// <inheritdoc/>
    public override string ToString()
        => HasPoints ? $"{amount} {nameof(Points)}" : $"No {nameof(Points)}";
    /// <summary>
    /// Constructs a new instance of points.
    /// </summary>
    /// <param name="points">The amount to be given.</param>
    /// <returns>A new instance of <see cref="Points"/>.</returns>
    public static Points Create(uint points)
        => new(points);
    /// <summary>
    /// <inheritdoc cref="Create(uint)" path="/summary"/>
    /// </summary>
    /// <param name="points"></param>
    /// <returns><inheritdoc cref="Create(uint)" path="/returns"/></returns>
    /// <exception cref="PointsOutOfRange">Thrown if the value is below 0.</exception>
    public static Points Create(int points)
    {
        if (points < 0)
            throw new PointsOutOfRange
            {
                Minimum = 0,
                Received = points
            };
        return Create((uint) points);
    }
    /// <summary>
    /// Gets the max between the points.
    /// </summary>
    /// <param name="left">The left most to compare.</param>
    /// <param name="right">The right most to compare.</param>
    /// <returns>The maximum of the two, the left if it is equal.</returns>
    public static Points Max(Points left, Points right)
    {
        if (right > left)
            return right;
        return left;
    }
    /// <summary>
    /// Will cast from a <see cref="uint"/> to a new <see cref="Points"/>.
    /// </summary>
    /// <param name="points">The value to cast from.</param>
    public static implicit operator Points(uint points)
        => Create(points);
    /// <summary>
    /// Will cast from an <see cref="int"/> to a new <see cref="Points"/>.
    /// </summary>
    /// <param name="points">The value to cast from.</param>
    /// <exception cref="PointsCastException">Thrown if the casting fails.</exception>
    public static implicit operator Points(int points)
    {
        try
        {
            return Create(points);
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
        => new(left.amount + right.amount);
    /// <summary>
    /// Multiplies the points together.
    /// </summary>
    /// <param name="left">The left point to multiply.</param>
    /// <param name="right">The right point to multiply.</param>
    /// <returns>A new <see cref="Points"/> after being multiplied.</returns>
    public static Points operator *(Points left, Points right)
        => new(left.amount * right.amount);
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
    /// <summary>
    /// Will check if the <paramref name="left"/> is less than the <paramref name="right"/>.
    /// </summary>
    /// <param name="left">Left most to check.</param>
    /// <param name="right">Right most to check.</param>
    /// <returns><see langword="true"/> if it is less than the <paramref name="right"/>, <see langword="false"/> if not.</returns>
    public static bool operator <(Points left, Points right)
        => left.CompareTo(right) < 0;
    /// <summary>
    /// Will check if the <paramref name="left"/> is less or equal to the <paramref name="right"/>.
    /// </summary>
    /// <param name="left"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='left']"/></param>
    /// <param name="right"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='right']"/></param>
    /// <returns><see langword="true"/> if it is less or equal to the <paramref name="right"/>, <see langword="false"/> if not.</returns>
    public static bool operator <=(Points left, Points right)
        => left.CompareTo(right) <= 0;
    /// <summary>
    /// Will check if the <paramref name="left"/> is greater than the <paramref name="right"/>.
    /// </summary>
    /// <param name="left"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='left']"/></param>
    /// <param name="right"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='right']"/></param>
    /// <returns><see langword="true"/> if it is greater than the <paramref name="right"/>, <see langword="false"/> if not.</returns>
    public static bool operator >(Points left, Points right)
        => left.CompareTo(right) > 0;
    /// <summary>
    /// Will check if the <paramref name="left"/> is greater or equal to the <paramref name="right"/>.
    /// </summary>
    /// <param name="left"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='left']"/></param>
    /// <param name="right"><inheritdoc cref="operator {(Points, Points)" path="/param[@name='right']"/></param>
    /// <returns><see langword="true"/> if it is greater or equal to the <paramref name="right"/>, <see langword="false"/> if not.</returns>
    public static bool operator >=(Points left, Points right)
        => left.CompareTo(right) >= 0;
}
