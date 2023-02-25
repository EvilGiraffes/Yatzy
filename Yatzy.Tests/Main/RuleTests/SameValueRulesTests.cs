using Yatzy.Dices;
using Yatzy.PointsCalculators;
using Yatzy.Rules;

namespace Yatzy.Tests.Main.RuleTests;
public class SameValueRulesTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IDice> diceMock;
    readonly Mock<IPointsCalculator> pointsCalculatorMock;
    const string Identifier = nameof(SameValueRulesTests);
    public SameValueRulesTests(ITestOutputHelper output)
    {
        this.output = output;
        diceMock = new();
        pointsCalculatorMock = new();
    }
    [Fact]
    public void Points_OneItemInHand_CalculatesOnePoint()
    {
        int pointsPerValue = 10;
        int face = 1;
        int diceValue = face;
        Points expected = pointsPerValue;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(5);
        SameValueRule<IDice> rule = BuildRule(face, pointsPerValue);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(() => diceValue++);
        Points actual = rule.CalculatePoints(hand);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Points_FullHand_SumsAllPoints()
    {
        int pointsPerValue = 10;
        int face = 1;
        int amount = 5;
        Points expected = pointsPerValue * amount;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(amount);
        SameValueRule<IDice> rule = BuildRule(face, pointsPerValue);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(face);
        Points actual = rule.CalculatePoints(hand);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Points_NoneMatching_NotRecieved()
    {
        int pointsPerValue = 10;
        int face = 1;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(5);
        SameValueRule<IDice> rule = BuildRule(face, pointsPerValue);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(face + 1);
        Points actual = rule.CalculatePoints(hand);
        output.WriteResult(Points.Empty, actual);
        actual.Should().Be(Points.Empty);
    }
    SameValueRule<IDice> BuildRule(int face, int pointsPerValue)
    {
        pointsCalculatorMock.Setup(calculator => calculator.Calculate(It.IsAny<int>())).Returns(pointsPerValue);
        return new(Identifier, face, pointsCalculatorMock.Object);
    }
}
