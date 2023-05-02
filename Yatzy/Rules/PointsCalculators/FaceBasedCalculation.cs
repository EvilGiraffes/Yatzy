namespace Yatzy.Rules.PointsCalculators;
/// <summary>
/// Represents an <see cref="IPointsCalculator"/> which just returns the face value as the points.
/// </summary>
public sealed class FaceBasedCalculation : IPointsCalculator
{
    /// <inheritdoc/>
    public Points Calculate(int face)
        => face;
}
