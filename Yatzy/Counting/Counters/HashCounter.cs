using System.Collections;

using Serilog;

using Yatzy.Logging;

namespace Yatzy.Counting.Counters;
/// <summary>
/// Represents a counter with the use of hashing.
/// </summary>
/// <typeparam name="T"><inheritdoc cref="ICounter{T}" path="/typeparam"/></typeparam>
public sealed class HashCounter<T> : ICounter<T>
    where T : notnull
{
    readonly ILogger logger;
    readonly IDictionary<T, int> counter;
    internal const int InitialCount = 1;
    /// <summary>
    /// Constructs a new instance of <see cref="HashCounter{T}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    public HashCounter(ILogger logger) : this(logger, new Dictionary<T, int>())
    {
    }
    /// <summary>
    /// <inheritdoc cref="HashCounter(ILogger)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="HashCounter(ILogger)" path="/param[@name='logger']"/></param>
    /// <param name="counter">The initial counter used.</param>
    public HashCounter(ILogger logger, IDictionary<T, int> counter)
    {
        this.logger = logger.ForType<HashCounter<T>>();
        this.counter = counter;
    }
    /// <inheritdoc/>
    public void Count(T key)
    {
        if (!counter.ContainsKey(key))
        {
            logger.Debug("New key added to the counter {Key}, with the initial count of {InitialCount}", key, InitialCount);
            counter[key] = InitialCount;
            return;
        }
        counter[key]++;
        logger.Debug("Updated the count for the key {Key} to {Count}", key, counter[key]);
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
