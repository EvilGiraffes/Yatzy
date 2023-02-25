﻿using Yatzy.Dices;
using Yatzy.PointsCalculators;
using Yatzy.Rules;

namespace Yatzy.Tests.Main.RuleTests;
public class YatzyRuleTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IDice> diceMock;
    readonly IPointsCalculator pointsCalculator;
    readonly Points fixedPoints;
    readonly YatzyRule<IDice> systemUnderTest;
    public YatzyRuleTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        diceMock = new();
        fixedPoints = 10;
        pointsCalculator = new FixedPointsPerValue(fixedPoints);
        systemUnderTest = new(loggerMock.Object, pointsCalculator);
    }
    [Fact]
    public void CalculatePoints_Yatzy_Points()
    {
        const int amount = 5;
        const int face = 5;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(amount);
        diceMock.Setup(dice => dice.Face).Returns(face);
        Points expected = fixedPoints * amount;
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_NotYatzy_Zero()
    {
        const int amount = 5;
        int count = 0;
        int face = 0;
        IReadOnlyList<IDice> hand = diceMock.BuildHand(amount);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(() =>
            {
                if (count >= amount - 1)
                    return face + 1;
                count++;
                return face;
            });
        Points expected = Points.Empty;
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
}