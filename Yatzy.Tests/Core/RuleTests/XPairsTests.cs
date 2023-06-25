using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;
using Yatzy.Tests.Core.RuleTests.Helpers;

namespace Yatzy.Tests.Core.RuleTests;
public sealed class XPairsTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    readonly Mock<ISet<int>> setMock;
    readonly Mock<IDice> diceMock;
    public XPairsTests(ITestOutputHelper output)
    {
        this.output = output;
        pointsCalculatorMock = new();
        counterMock = new();
        setMock = new();
        diceMock = new();
    }
    [Fact]
    public void CalculatePoints_OnePair_Points()
    {
        XPairs<IDice> systemUnderTest = CreateRule(1);
        int face = 5;
        Points expected = 10;
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(1);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(face);
        counterMock
            .SetupGet(counter => counter[It.IsAny<int>()])
            .Returns(2);
        pointsCalculatorMock.CalculationReturnsFace();
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_NoPairs_NoPoints()
    {
        XPairs<IDice> systemUnderTest = CreateRule(1);
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(1);
        counterMock
            .SetupGet(counter => counter[It.IsAny<int>()])
            .Returns(1);
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_UnCalculatedPair_AddsPairToSet()
    {
        XPairs<IDice> systemUnderTest = CreateRule(1);
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(1);
        counterMock
            .SetupGet(counter => counter[It.IsAny<int>()])
            .Returns(2);
        setMock
            .Setup(set => set.Contains(It.IsAny<int>()))
            .Returns(false);
        _ = systemUnderTest.CalculatePoints(hand);
        setMock.Verify(set => set.Add(It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void CalculatePoints_CalculatedPair_DoesNotAddToSet()
    {
        XPairs<IDice> systemUnderTest = CreateRule(1);
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(1);
        counterMock
            .SetupGet(counter => counter[It.IsAny<int>()])
            .Returns(2);
        setMock
            .Setup(set => set.Contains(It.IsAny<int>()))
            .Returns(true);
        _ = systemUnderTest.CalculatePoints(hand);
        setMock.Verify(set => set.Add(It.IsAny<int>()), Times.Never);
    }
    XPairs<IDice> CreateRule(int x = XPairs<IDice>.Minimum)
    {
        ILogger logger = LoggerHelper.GetTestOutputLogger<XPairsTests>(output);
        StringTransform<int> transform = TransformHelper.SimpleTransform;
        CounterFactory<int> counterFactor = () => counterMock.Object;
        return new(logger, x, transform, pointsCalculatorMock.Object, counterFactor, () => setMock.Object);
    }
}
