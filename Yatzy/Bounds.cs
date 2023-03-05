using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents a boundary.
/// </summary>
public readonly record struct Bounds
{

    /// <summary>
    /// The low point of the boundary.
    /// </summary>
    public int Low { get; }
    /// <summary>
    /// The high point of the boundary.
    /// </summary>
    public int High { get; }
    /// <summary>
    /// Constructs a new instance of <see cref="Bounds"/>.
    /// </summary>
    /// <param name="low">The lower value.</param>
    /// <param name="high">The higher value.</param>
    /// <exception cref="BoundsInvalidConstructorArgument">Thrown if the <paramref name="low"/> value greater than the <paramref name="high"/> value.</exception>
    public Bounds(int low, int high)
    {
        if (low > high)
            throw new BoundsInvalidConstructorArgument($"The {nameof(low)} value is higher than or equal to the {nameof(high)} value.", nameof(low))
            {
                Low = low,
                High = high
            };
        Low = low;
        High = high;
    }
}
