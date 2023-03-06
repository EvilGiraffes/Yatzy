using Yatzy.Counting;
using Yatzy.Counting.Counters;
using Yatzy.Dices;
using Yatzy.PointsCalculators;
using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Tests.Core.RuleTests;
public static class RuleHelper
{
    public static IReadOnlyList<IDice> EmptyHand
        => Array.Empty<IDice>();
    public static IReadOnlyList<IDice> BuildHand(this Mock<IDice> diceMock, int count = 5)
    {
        IDice[] hand = new IDice[count];
        for (int i = 0; i < count; i++)
            hand[i] = diceMock.Object;
        return hand;
    }
    public static void SetAsEnumeratorFor<T>(this IEnumerable<Count<T>> counts, Mock<ICounter<T>> counterMock)
        where T : notnull
        => counterMock.Setup(counter => counter.GetEnumerator()).Returns(counts.GetEnumerator());
    public static void CalculationReturnsFace(this Mock<IPointsCalculator> pointsCalculator)
        => pointsCalculator.Setup(calculator => calculator.Calculate(It.IsAny<int>())).Returns((int face) => face);
    public static void SpliceReturns(this Mock<ISpliceStrategy> spliceMock, Bounds bounds)
        => spliceMock.Setup(splicer => splicer.Splice(It.IsAny<int>())).Returns(bounds);
}
