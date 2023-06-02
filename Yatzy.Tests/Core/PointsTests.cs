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
    public void Create_ValidPoints_DoesNotThrowException()
    {
        Action act = () => _ = Points.Create(0);
        output.Write().Expecting(act).ToThrow<PointsOutOfRange>();
        act.Should().NotThrow<PointsOutOfRange>();
    }
    [Fact]
    public void Create_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = Points.Create(0 - 1);
        output.Write().Expecting(act).ToThrow<PointsOutOfRange>();
        act.Should().Throw<PointsOutOfRange>();
    }
    [Fact]
    public void Cast_ValidPoints_DoesNotThrowException()
    {
        Action act = () => _ = (Points) 0;
        output.Write().Expecting(act).ToNotThrowException();
        act.Should().NotThrow<PointsCastException>();
    }
    [Fact]
    public void Cast_InvalidPoints_ThrowsException()
    {
        Action act = () => _ = (Points) (0 - 1);
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
        Points points = 0 + 1;
        output.Write().Expecting(points.HasPoints).ToBeTrue();
        points.HasPoints.Should().BeTrue();
    }
    [Fact]
    public void HasPoints_AtMinimum_False()
    {
        Points points = 0;
        output.Write().Expecting(points.HasPoints).ToBeFalse();
        points.HasPoints.Should().BeFalse();
    }
    [Fact]
    public void Max_RightIsMax_Right()
    {
        Points left = 0 + 1;
        Points right = left + 1;
        Points expected = right;
        Points actual = Points.Max(left, right);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Max_LeftIsMax_Left()
    {
        Points right = 0 + 1;
        Points left = right + 1;
        Points expected = left;
        Points actual = Points.Max(left, right);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Max_Equal_HasSameAmount()
    {
        int expectedAmount = 0 + 1;
        Points expected = expectedAmount;
        Points left = expectedAmount;
        Points right = expectedAmount;
        Points actual = Points.Max(left, right);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
}
