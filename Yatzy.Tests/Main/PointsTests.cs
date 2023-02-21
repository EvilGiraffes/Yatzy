using Yatzy.Errors;

namespace Yatzy.Tests.Main;
public class PointsTests
{
    readonly ITestOutputHelper output;
    public PointsTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    [Fact]
    public void Ctor_ValidPoints_DoesNotThrowException()
    {
        Action act = () => _ = new Points(Points.MinimumPoints);
        act.Should().NotThrow<PointsOutOfRange>();
    }
    [Fact]
    public void Ctor_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = new Points(Points.MinimumPoints - 1);
        act.Should().Throw<PointsOutOfRange>();
    }
    [Fact]
    public void Cast_ValidPoints_DoesNotThrowException()
    {
        Action act = () => _ = (Points) Points.MinimumPoints;
        act.Should().NotThrow<PointsCastException>();
    }
    [Fact]
    public void Cast_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = (Points) (Points.MinimumPoints - 1);
        act.Should()
            .Throw<PointsCastException>()
            .And
            .InnerException.Should()
            .BeOfType<PointsOutOfRange>();
    }
    [Fact]
    public void HasPoints_AboveMinimum_True()
    {
        Points points = new(Points.MinimumPoints + 1);
        output.WriteExpectedTrue(points.HasPoints);
        points.HasPoints.Should().BeTrue();
    }
    [Fact]
    public void HasPoints_AtMinimum_False()
    {
        Points points = new(Points.MinimumPoints);
        output.WriteExpectedFalse(points.HasPoints);
        points.HasPoints.Should().BeFalse();
    }
}
