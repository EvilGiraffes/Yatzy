using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.Errors;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Tests.Core.RuleTests;
public sealed class XPairsBuilderTests
{
    readonly XPairsBuilder<IDice> systemUnderTest;
    readonly Mock<StringTransform<int>> transformMock;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    readonly Mock<ICounter<int>> counterMock;
    readonly CounterFactory<int> counterFactory;
    readonly Mock<ISet<int>> setMock;
    readonly Func<ISet<int>> setFactory;
    const int MinimumX = XPairs<IDice>.Minimum;
    public XPairsBuilderTests(ITestOutputHelper output)
    {
        ILogger logger = LoggerHelper.GetTestOutputLogger<XOfAKindBuilderTests>(output);
        transformMock = new();
        pointsCalculatorMock = new();
        counterMock = new();
        counterFactory = () => counterMock.Object;
        setMock = new();
        setFactory = () => setMock.Object;
        systemUnderTest = new(logger);
    }
    [Fact]
    public void Build_AllValuesValid_NoException()
    {
        Action act = () =>
        {
            _ = systemUnderTest
            .X(MinimumX)
            .XTransform(transformMock.Object)
            .PointsCalculator(pointsCalculatorMock.Object)
            .CounterFactory(counterFactory)
            .SetFactory(setFactory)
            .Build();
        };
        act.Should().NotThrow();
    }
    [Fact]
    public void Build_RequiredValuesValid_NoException()
    {
        Action act = () =>
        {
            _ = systemUnderTest
            .X(MinimumX)
            .PointsCalculator(pointsCalculatorMock.Object)
            .Build();
        };
        act.Should().NotThrow();
    }
    [Fact]
    public void Build_NoValues_Exception()
    {
        Action act = () =>
        {
            _ = systemUnderTest
            .Build();
        };
        act.Should().Throw<BuildingFailed>();
    }
    [Fact]
    public void Build_XNotSet_Exception()
    {
        Action act = () =>
        {
            _ = systemUnderTest
            .PointsCalculator(pointsCalculatorMock.Object)
            .Build();
        };
        act.Should().Throw<BuildingFailed>();
    }
    [Fact]
    public void Build_PointsCalculatorNotSet_Exception()
    {
        Action act = () =>
        {
            _ = systemUnderTest
            .X(MinimumX)
            .Build();
        };
        act.Should().Throw<BuildingFailed>();
    }
}
