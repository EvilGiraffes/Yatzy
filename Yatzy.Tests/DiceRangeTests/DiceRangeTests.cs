using Yatzy.Errors;

namespace Yatzy.Tests.DiceRangeTests;
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
        output.WriteExpectedTrue(actual);
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
        output.WriteExpectedFalse(actual);
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
        output.WriteExpectedFalse(actual);
        actual.Should().BeFalse();
    }
    [Fact]
    public void PropertyInitMinimum_ValidRange_DoesNotThrowException()
    {
        Action init = () => _ = new DiceRange
        {
            MinimumFace = DiceRange.MinimumLowerBound,
            MaximumFace = int.MaxValue
        };
        init.Should().NotThrow<DiceRangeBelowMinium>();
    }
    [Fact]
    public void PropertyInitMinimum_InvalidRange_ThrowsException()
    {
        Action faultyInit = () => _ = new DiceRange
        {
            MinimumFace = DiceRange.MinimumLowerBound - 1,
            MaximumFace = int.MaxValue
        };
        faultyInit.Should().Throw<DiceRangeBelowMinium>();
    }
    [Fact]
    public void Ctor_MinimumInRange_DoesNotThrowException()
    {
        Action ctor = () => _ = new DiceRange(DiceRange.MinimumLowerBound, int.MaxValue);
        ctor.Should().NotThrow<DiceRangeBelowMinium>();
    }
    [Fact]
    public void Ctor_MinumumOutOfRange_ThrowsException()
    {
        Action faultyCtor = () => _ = new DiceRange(DiceRange.MinimumLowerBound - 1, int.MaxValue);
        faultyCtor.Should().Throw<DiceRangeBelowMinium>();
    }
}
