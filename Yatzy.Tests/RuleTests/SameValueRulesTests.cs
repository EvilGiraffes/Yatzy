using Yatzy.Dices;
using Yatzy.Rules;

namespace Yatzy.Tests.RuleTests;
public class SameValueRulesTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IDice> diceMock;
    const string Identifier = nameof(SameValueRulesTests);
    public SameValueRulesTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        diceMock = new();
    }
    [Fact]
    public void Points_OneItemInHand_CalculatesOnePoint()
    {
        int pointsPerValue = 10;
        int face = 1;
        int diceValue = face;
        Points expected = pointsPerValue;
        IReadOnlyList<IDice> hand = BuildHand(5);
        SameValueRule rule = BuildRule(face, pointsPerValue);
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
        IReadOnlyList<IDice> hand = BuildHand(amount);
        SameValueRule rule = BuildRule(face, pointsPerValue);
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
        IReadOnlyList<IDice> hand = BuildHand(5);
        SameValueRule rule = BuildRule(face, pointsPerValue);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(face + 1);
        Points actual = rule.CalculatePoints(hand);
        output.WriteResult(Points.Empty, actual);
        actual.Should().Be(Points.Empty);
    }
    SameValueRule BuildRule(int face, int pointsPerValue)
        => new(loggerMock.Object, Identifier, face, pointsPerValue);
    IReadOnlyList<IDice> BuildHand(int count)
    {
        List<IDice> dices = new();
        for (int i = 0; i < count; i++)
            dices.Add(diceMock.Object);
        return dices;
    }
}
