using Yatzy.Errors;

namespace Yatzy.Tests;
public class PointsTests
{
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
        act.Should().NotThrow<InvalidCastException>();
    }
    [Fact]
    public void Cast_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = (Points) (Points.MinimumPoints - 1);
        act.Should()
            .Throw<InvalidCastException>()
            .And
            .InnerException.Should()
            .BeOfType<PointsOutOfRange>();
    }
}
