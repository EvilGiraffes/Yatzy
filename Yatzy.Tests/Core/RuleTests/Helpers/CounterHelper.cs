using Yatzy.Counting;
using Yatzy.Counting.Counters;

namespace Yatzy.Tests.Core.RuleTests.Helpers;
public static class CounterHelper
{
    public static void SetAsEnumeratorFor<T>(this IEnumerable<Count<T>> counts, Mock<ICounter<T>> counterMock)
        where T : notnull
        => counterMock.Setup(counter => counter.GetEnumerator()).Returns(counts.GetEnumerator());
}
