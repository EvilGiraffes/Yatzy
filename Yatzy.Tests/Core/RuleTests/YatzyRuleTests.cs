﻿using Yatzy.Dices;
using Yatzy.Rules;
using Yatzy.Rules.PointsCalculators;
using Yatzy.Tests.Core.FluentAssertionExt;
using Yatzy.Tests.Core.RuleTests.Helpers;

namespace Yatzy.Tests.Core.RuleTests;
public class YatzyRuleTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IDice> diceMock;
    readonly IPointsCalculator pointsCalculator;
    readonly Points fixedPoints;
    readonly YatzyRule<IDice> systemUnderTest;
    public YatzyRuleTests(ITestOutputHelper output)
    {
        this.output = output;
        ILogger logger = LoggerHelper.GetTestOutputLogger<YatzyRuleTests>(output);
        diceMock = new();
        fixedPoints = 10;
        pointsCalculator = new FixedPointsPerValue(fixedPoints);
        systemUnderTest = new(logger, pointsCalculator);
    }
    [Fact]
    public void CalculatePoints_Yatzy_Points()
    {
        const int amount = 5;
        const int face = 5;
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(amount);
        diceMock.Setup(dice => dice.Face).Returns(face);
        Points expected = fixedPoints * amount;
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void CalculatePoints_NotYatzy_Zero()
    {
        const int amount = 5;
        int count = 0;
        int face = 0;
        IReadOnlyCollection<IDice> hand = diceMock.BuildHand(amount);
        diceMock
            .Setup(dice => dice.Face)
            .Returns(() =>
            {
                if (count >= amount - 1)
                    return face + 1;
                count++;
                return face;
            });
        Points actual = systemUnderTest.CalculatePoints(hand);
        output.Write().Expecting(actual).ToBeEmpty();
        actual.Should().BeEmpty();
    }
}
