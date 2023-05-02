using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;

using static Yatzy.Tests.Core.RuleTests.RuleHelper;

namespace Yatzy.Tests.Core.RuleTests;
// TODO: Finish.
public class XOfAKindTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    readonly Mock<IDice> diceMock;
    readonly CounterFactory<int> counterFactory;
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
    [InlineData(XOfAKind<IDice>.MinimumCount)]
    [InlineData(XOfAKind<IDice>.MaximumCount)]
    public void Ctor_InRange_NoException(int x)
    {
        Action act = () => _ = CreateRule(x);
        output.Write().Expecting(act).ToThrow<XOfAKindOutOfRange>();
        act.Should().NotThrow<XOfAKindOutOfRange>();
    }
    [Fact]
    public void Ctor_OutOfRange_ThrowsException()
    {
        int x = XOfAKind<IDice>.MinimumCount - 1;
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
        counterMock
            .Setup(counter => counter.GetEnumerator())
            .Returns(hand.GetEnumerator());
        Points actual = rule.CalculatePoints(AnyHand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_ValidHand_CalcultesPoints()
    {
        // TODO: Complete.
    }
    string SimpleTransform(int x)
        => x.ToString();
    XOfAKind<IDice> CreateRule(XOfAKind<IDice>.XTransform transform, int x = XOfAKind<IDice>.MinimumCount)
        => new(loggerMock.Object, x, transform, pointsCalculatorMock.Object, counterFactory);
    XOfAKind<IDice> CreateRule(int x = XOfAKind<IDice>.MinimumCount)
        => CreateRule(SimpleTransform, x);
}
