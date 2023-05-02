using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;
using Yatzy.Tests.Core.FluentAssertionExt;

namespace Yatzy.Tests.Core.RuleTests;
public class TwoSplicedRuleTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IDice> diceMock;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<ISpliceStrategy> spliceMock;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    readonly TwoSplicedRule<IDice> systemUnderTest;
    const string Identifier = nameof(TwoSplicedRuleTests);
    public TwoSplicedRuleTests(ITestOutputHelper output)
    {
        this.output = output;
        diceMock = new();
        loggerMock = MockHelper.GetLogger();
        spliceMock = new();
        pointsCalculatorMock = new();
        counterMock = new();
        systemUnderTest = new(loggerMock.Object, Identifier, spliceMock.Object, pointsCalculatorMock.Object, () => counterMock.Object);
    }
    [Fact]
    public void CalculatePoints_EmptyHand_NoPoints()
    {
        IReadOnlyList<IDice> emptyHand = RuleHelper.EmptyHand;
        Points actual = systemUnderTest.CalculatePoints(emptyHand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_NoDiceAboveHighCount_NoPoints()
    {
        Bounds bounds = new(2, 3);
        IEnumerable<Count<int>> counts = new Count<int>[]
        {
            new(1, bounds.Low),
            new(2, 1),
            new(3, 1)
        };
        counts.SetAsEnumeratorFor(counterMock);
        spliceMock.SpliceReturns(bounds);
        Points actual = systemUnderTest.CalculatePoints(diceMock.BuildHand());
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_AllAboveHighBound_Points()
    {
        Bounds bounds = new(2, 3);
        int minPoint = 1;
        int maxPoint = 2;
        IEnumerable<Count<int>> counts = new Count<int>[]
        {
            new(minPoint, bounds.High),
            new(maxPoint, bounds.High)
        };
        counts.SetAsEnumeratorFor(counterMock);
        pointsCalculatorMock.CalculationReturnsFace();
        spliceMock.SpliceReturns(bounds);
        Points expected = CalculateExpected(maxPoint, minPoint, bounds);
        Points actual = systemUnderTest.CalculatePoints(diceMock.BuildHand());
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_OldHighBoundHigherThanLowBound_Points()
    {
        Bounds bounds = new(2, 3);
        int minPoint = 2;
        int maxPoint = 3;
        IEnumerable<Count<int>> counts = new Count<int>[]
        {
            new(minPoint - 1, bounds.Low),
            new(minPoint, bounds.High),
            new(maxPoint, bounds.High)
        };
        counts.SetAsEnumeratorFor(counterMock);
        pointsCalculatorMock.CalculationReturnsFace();
        spliceMock.SpliceReturns(bounds);
        Points expected = CalculateExpected(maxPoint, minPoint, bounds);
        Points actual = systemUnderTest.CalculatePoints(diceMock.BuildHand());
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_FacesAreBelowOne_NoPoints()
    {
        Bounds bounds = new(2, 3);
        IEnumerable<Count<int>> counts = new Count<int>[]
        {
            new(-1, bounds.Low),
            new(0, bounds.High)
        };
        counts.SetAsEnumeratorFor(counterMock);
        spliceMock.SpliceReturns(bounds);
        Points actual = systemUnderTest.CalculatePoints(diceMock.BuildHand());
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    static Points CalculateExpected(int max, int min, Bounds bounds)
        => max * bounds.High + min * bounds.Low;
}
