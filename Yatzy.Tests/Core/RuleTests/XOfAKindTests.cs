using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;
using Yatzy.Tests.Core.RuleTests.Helpers;

using static Yatzy.Tests.Core.RuleTests.Helpers.RuleHelper;

namespace Yatzy.Tests.Core.RuleTests;
public class XOfAKindTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    readonly Mock<IDice> diceMock;
    readonly CounterFactory<int> counterFactory;
    const int MinimumCount = XOfAKind<IDice>.MinimumCount;
    const int MaximumCount = XOfAKind<IDice>.MaximumCount;
    public XOfAKindTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        pointsCalculatorMock = new();
        counterMock = new();
        diceMock = new();
        counterFactory = () => counterMock.Object;
    }
    [Theory]
    [InlineData(MinimumCount)]
    [InlineData(MaximumCount)]
    public void Ctor_InRange_NoException(int x)
    {
        Action act = () => _ = CreateRule(x);
        output.Write().Expecting(act).ToThrow<XOfAKindOutOfRange>();
        act.Should().NotThrow<XOfAKindOutOfRange>();
    }
    [Fact]
    public void Ctor_OutOfRange_ThrowsException()
    {
        int x = MinimumCount - 1;
        Action act = () => _ = CreateRule(x);
        output.Write().Expecting(act).ToThrow<XOfAKindOutOfRange>();
        act.Should().Throw<XOfAKindOutOfRange>();
    }
    [Fact]
    public void CalculatePoints_EmptyHand_EmptyPoints()
    {
        XOfAKind<IDice> rule = CreateRule();
        counterMock
            .Setup(counter => counter.GetEnumerator())
            .Returns(Enumerable.Empty<Count<int>>().GetEnumerator());
        Points actual = rule.CalculatePoints(AnyHand);
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
        Points actual = rule.CalculatePoints(AnyHand);
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
        Points actual = rule.CalculatePoints(AnyHand);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    string SimpleTransform(int x)
        => x.ToString();
    XOfAKind<IDice> CreateRule(StringTransform<int> transform, int x = MinimumCount)
        => new(loggerMock.Object, x, transform, pointsCalculatorMock.Object, counterFactory);
    XOfAKind<IDice> CreateRule(int x = MinimumCount)
        => CreateRule(SimpleTransform, x);
}
