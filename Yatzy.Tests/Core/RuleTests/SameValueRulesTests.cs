using Yatzy.Dices;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;
using Yatzy.Tests.Core.RuleTests.Helpers;

namespace Yatzy.Tests.Core.RuleTests;
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
    public void CalculatePoints_NoItemsInHand_NoPoints()
    {
        IReadOnlyList<IDice> hand = RuleHelper.EmptyHand;
        SameValueRule<IDice> rule = BuildRule(1, 1);
        Points actual = rule.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    [Fact]
    public void CalculatePoints_OneItemInHand_CalculatesOnePoint()
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
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_FullHand_SumsAllPoints()
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
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_NoneMatching_NotRecieved()
    {
        int pointsPerValue = 10;
        int face = 1;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(5);
        SameValueRule<IDice> rule = BuildRule(face, pointsPerValue);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(face + 1);
        Points actual = rule.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
    SameValueRule<IDice> BuildRule(int face, int pointsPerValue)
    {
        pointsCalculatorMock.Setup(calculator => calculator.Calculate(It.IsAny<int>())).Returns(pointsPerValue);
        return new(Identifier, face, pointsCalculatorMock.Object);
    }
}
