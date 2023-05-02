using Yatzy.Extentions;

namespace Yatzy.Counting.Counters;
/// <summary>
/// Extentions for the <see cref="ICounter{T}"/>.
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
        => items.Pipe(counter.Count);
    /// <summary>
    /// Filters the counter by the count.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="ICounter{T}" path="/typeparam"/></typeparam>
    /// <param name="counter"><inheritdoc cref="Count{T}(ICounter{T}, IEnumerable{T})" path="/param[@name='counter']"/></param>
    /// <param name="predicate">The predicate to filter the count by.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> which returns the filtered count.</returns>
    public static IEnumerable<Count<T>> FilterByAmount<T>(this ICounter<T> counter, Func<int, bool> predicate)
        where T : notnull
    {
        foreach (Count<T> count in counter)
            if (predicate(count.Amount))
                yield return count;
    }
}
