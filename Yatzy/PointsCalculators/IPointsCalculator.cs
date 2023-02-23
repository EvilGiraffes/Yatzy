namespace Yatzy.PointsCalculators;
/// <summary>
/// Represents a an object capable of giving points based on the value.
/// </summary>
public interface IPointsCalculator
{
    /// <summary>
    /// Calculates the points based on the sum.
    /// </summary>
    /// <param name="face">The face to base the calculation of.</param>
    /// <returns>a new <see cref="Points"/> representing the points given.</returns>
    Points Calculate(int face);
}
