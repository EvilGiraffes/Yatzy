using Yatzy.Errors;
using Yatzy.Tests.Core.FluentAssertionExt;

namespace Yatzy.Tests.Core;
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
        output.Write().Expecting(act).ToThrow<PointsOutOfRange>();
        act.Should().NotThrow<PointsOutOfRange>();
    }
    [Fact]
    public void Ctor_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = new Points(Points.MinimumPoints - 1);
        output.Write().Expecting(act).ToThrow<PointsOutOfRange>();
        act.Should().Throw<PointsOutOfRange>();
    }
    [Fact]
    public void Cast_ValidPoints_DoesNotThrowException()
    {
        Action act = () => _ = (Points) Points.MinimumPoints;
        output.Write().Expecting(act).ToNotThrowException();
        act.Should().NotThrow<PointsCastException>();
    }
    [Fact]
    public void Cast_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = (Points) (Points.MinimumPoints - 1);
        output.Write().Expecting(act).ToThrow<PointsOutOfRange>();
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
        output.Write().Expecting(points.HasPoints).ToBeTrue();
        points.HasPoints.Should().BeTrue();
    }
    [Fact]
    public void HasPoints_AtMinimum_False()
    {
        Points points = new(Points.MinimumPoints);
        output.Write().Expecting(points.HasPoints).ToBeFalse();
        points.HasPoints.Should().BeFalse();
    }
    [Fact]
    public void Max_RightIsMax_Right()
    {
        Points left = new(Points.MinimumPoints + 1);
        Points right = left + 1;
        Points expected = right;
        Points actual = Points.Max(left, right);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Max_LeftIsMax_Left()
    {
        Points right = new(Points.MinimumPoints + 1);
        Points left = right + 1;
        Points expected = left;
        Points actual = Points.Max(left, right);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Max_Equal_HasSameAmount()
    {
        int expected = Points.MinimumPoints + 1;
        Points left = new(expected);
        Points right = new(expected);
        int actual = Points.Max(left, right).Amount;
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
}
