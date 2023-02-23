using Yatzy.Counting.Counters;
using Yatzy.Utils;

namespace Yatzy.Counting;
/// <summary>
/// Extentions for the ICounters.
/// </summary>
public static class ICounterExt
{
    /// <summary>
    /// Counts every item in the enumerable.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="ICounter{T}" path="/typeparam"/></typeparam>
    /// <param name="counter">The counter object to count with.</param>
    /// <param name="items">The items to count.</param>
    public static void Count<T>(this ICounter<T> counter, IEnumerable<T> items)
        where T : notnull
        => items.Call(counter.Count);
}
