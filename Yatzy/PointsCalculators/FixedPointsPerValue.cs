namespace Yatzy.PointsCalculators;
/// <summary>
/// Represents an <see cref="IPointsCalculator"/> which gives fixed points per calculation.
/// </summary>
public sealed class FixedPointsPerValue : IPointsCalculator
{
    readonly Points points;
    /// <summary>
    /// Creates an instance of <see cref="FixedPointsPerValue"/>.
    /// </summary>
    /// <param name="points">The number of points given per calculation.</param>
    public FixedPointsPerValue(Points points)
    {
        this.points = points;
    }
    /// <inheritdoc/>
    public Points Calculate(int _)
        => points;
}
