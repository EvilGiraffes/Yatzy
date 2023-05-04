using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Tests.Core.RuleTests.Helpers;

public static class PointsCalculatorHelper
{
    public static void CalculationReturnsFace(this Mock<IPointsCalculator> pointsCalculator)
        => pointsCalculator.Setup(calculator => calculator.Calculate(It.IsAny<int>())).Returns((int face) => face);
}