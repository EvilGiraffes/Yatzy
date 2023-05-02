using Yatzy.Errors;

namespace Yatzy.Tests.Core;
public class DiceRangeTests
{
    readonly ITestOutputHelper output;
    readonly DiceRange systemUnderTest;
    const int MinimumFace = DiceRange.MinimumLowerBound + 10;
    const int MaximumFace = 100;
    public DiceRangeTests(ITestOutputHelper output)
    {
        this.output = output;
        systemUnderTest = new(MinimumFace, MaximumFace);
    }
    [Fact]
    public void InRangeOf_InRange_True()
    {
        DiceRange otherRange = new()
        {
            MinimumFace = MinimumFace,
            MaximumFace = MaximumFace
        };
        bool actual = systemUnderTest.InRangeOf(otherRange);
        output.Write().Expecting(actual).ToBeTrue();
        actual.Should().BeTrue();
    }
    [Fact]
    public void InRangeOf_MinimumTooSmall_False()
    {
        DiceRange otherRange = new()
        {
            MinimumFace = MinimumFace - 1,
            MaximumFace = MaximumFace
        };
        bool actual = systemUnderTest.InRangeOf(otherRange);
        output.Write().Expecting(actual).ToBeFalse();
        actual.Should().BeFalse();
    }
    [Fact]
    public void InRangeOf_MaximumTooLarge_False()
    {
        DiceRange otherRange = new()
        {
            MinimumFace = MinimumFace,
            MaximumFace = MaximumFace + 1
        };
        bool actual = systemUnderTest.InRangeOf(otherRange);
        output.Write().Expecting(actual).ToBeFalse();
        actual.Should().BeFalse();
    }
    [Fact]
    public void PropertyInitMinimum_ValidRange_DoesNotThrowException()
    {
        Action act = () => _ = new DiceRange
        {
            MinimumFace = DiceRange.MinimumLowerBound,
            MaximumFace = int.MaxValue
        };
        output.Write().Expecting(act).ToNotThrowException();
        act.Should().NotThrow<DiceRangeBelowMinium>();
    }
    [Fact]
    public void PropertyInitMinimum_InvalidRange_ThrowsException()
    {
        Action act = () => _ = new DiceRange
        {
            MinimumFace = DiceRange.MinimumLowerBound - 1,
            MaximumFace = int.MaxValue
        };
        output.Write().Expecting(act).ToThrow<DiceRangeBelowMinium>();
        act.Should().Throw<DiceRangeBelowMinium>();
    }
    [Fact]
    public void Ctor_MinimumInRange_DoesNotThrowException()
    {
        Action act = () => _ = new DiceRange(DiceRange.MinimumLowerBound, int.MaxValue);
        output.Write().Expecting(act).ToNotThrowException();
        act.Should().NotThrow<DiceRangeBelowMinium>();
    }
    [Fact]
    public void Ctor_MinumumOutOfRange_ThrowsException()
    {
        Action act = () => _ = new DiceRange(DiceRange.MinimumLowerBound - 1, int.MaxValue);
        output.Write().Expecting(act).ToThrow<DiceRangeBelowMinium>();
        act.Should().Throw<DiceRangeBelowMinium>();
    }
}
