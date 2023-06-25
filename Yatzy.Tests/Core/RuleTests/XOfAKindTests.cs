using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;
using Yatzy.Tests.Core.RuleTests.Helpers;

namespace Yatzy.Tests.Core.RuleTests;
public class XOfAKindTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    const int MinimumCount = XOfAKind<IDice>.Minimum;
    const int MaximumCount = XOfAKind<IDice>.Maximum;
    public XOfAKindTests(ITestOutputHelper output)
    {
        this.output = output;
        pointsCalculatorMock = new();
        counterMock = new();
    }
    [Theory]
    [InlineData(MinimumCount)]
    [InlineData(MaximumCount)]
    public void Ctor_InRange_NoException(int x)
    {
        Action act = () => _ = CreateRule(x);
        act.Should().NotThrow<XOutOfRange>();
    }
    [Fact]
    public void Ctor_OutOfRange_ThrowsException()
    {
        int x = MinimumCount - 1;
        Action act = () => _ = CreateRule(x);
        act.Should().Throw<XOutOfRange>();
    }
    [Fact]
    public void CalculatePoints_EmptyHand_EmptyPoints()
    {
        XOfAKind<IDice> rule = CreateRule();
        counterMock
            .Setup(counter => counter.GetEnumerator())
            .Returns(Enumerable.Empty<Count<int>>().GetEnumerator());
        Points actual = rule.CalculatePoints(RuleHelper.AnyHand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_NonValidHand_EmptyPoints()
    {
        XOfAKind<IDice> rule = CreateRule(3);
        List<Count<int>> hand = new()
        {
            new(1, 1),
            new(2, 2),
            new(3, 2)
        };
        hand.SetAsEnumeratorFor(counterMock);
        Points actual = rule.CalculatePoints(RuleHelper.AnyHand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Theory]
    [InlineData(MinimumCount, 1)]
    [InlineData(MaximumCount, 1)]
    [InlineData(MinimumCount, int.MaxValue / 2)]
    [InlineData(MaximumCount / 2, 2)]
    public void CalculatePoints_ValidHand_CalculatesPoints(int x, int face)
    {
        Points expected = face * x;
        XOfAKind<IDice> rule = CreateRule(x);
        List<Count<int>> hand = new()
        {
            new(face, x)
        };
        hand.SetAsEnumeratorFor(counterMock);
        pointsCalculatorMock.CalculationReturnsFace();
        Points actual = rule.CalculatePoints(RuleHelper.AnyHand);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    XOfAKind<IDice> CreateRule(int x = MinimumCount)
    {
        ILogger logger = LoggerHelper.GetTestOutputLogger<XOfAKindTests>(output);
        StringTransform<int> transform = TransformHelper.SimpleTransform;
        CounterFactory<int> counterFactor = () => counterMock.Object;
        return new(logger, x, transform, pointsCalculatorMock.Object, counterFactor);
    }
}
