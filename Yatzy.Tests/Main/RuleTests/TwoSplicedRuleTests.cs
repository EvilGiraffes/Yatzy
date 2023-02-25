using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.PointsCalculators;
using Yatzy.Rules;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Tests.Main.RuleTests;
// TODO: Finish tests.
public class TwoSplicedRuleTests
{
    readonly ITestOutputHelper output;
    readonly Mock<IRule<IDice>> ruleMock;
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
        ruleMock = new();
        diceMock = new();
        loggerMock = MockHelper.GetLogger();
        spliceMock = new();
        pointsCalculatorMock = new();
        counterMock = new();
        systemUnderTest = new(loggerMock.Object, Identifier, spliceMock.Object, pointsCalculatorMock.Object, () => counterMock.Object);
    }
    /*
     * Possbilities:
     * - Hand is empty and therefore counter is empty.                                          Expecting no points.
     * - Lower becomes the higher as the count is greater.                                      Expecting points.
     * - Lower is set between face and current lower.                                           Expecting Any.
     * - Only ever getting a Lower count.                                                       Expecting no points.
     * - High bound insures Low bound will get a new value if it is higher than the previous.   Expecting points.
     * - Max face or Min face is below 1 and returns empty points.                              Expecting no points.
     * - Both are above 1 and thereby calculates the points according to its formula.           Expecting points.
     */
}
