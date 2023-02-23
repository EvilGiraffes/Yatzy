using System.Collections;

namespace Yatzy.Counting.Counters;
/// <summary>
/// Represents a counter with the use of hashing.
/// </summary>
/// <typeparam name="T"><inheritdoc cref="ICounter{T}" path="/typeparam"/></typeparam>
public sealed class HashCounter<T> : ICounter<T>
    where T : notnull
{
    readonly Dictionary<T, int> counter = new();

    /// <inheritdoc/>
    public void Count(T key)
    {
        if (!counter.ContainsKey(key))
        {
            counter[key] = 1;
            return;
        }
        counter[key]++;
    }
    /// <inheritdoc/>
    public int GetCount(T key)
        => counter[key];
    /// <inheritdoc/>
    public bool Contains(T key)
        => counter.ContainsKey(key);
    /// <inheritdoc/>
    public void Clear()
        => counter.Clear();
    /// <inheritdoc/>
    public IEnumerator<Count<T>> GetEnumerator()
        => counter.Select(
            keyValuePair => new Count<T>(keyValuePair.Key, keyValuePair.Value))
        .GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
