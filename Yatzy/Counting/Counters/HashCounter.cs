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
    static IDictionary<T, int> DefaultDictionary
        => new Dictionary<T, int>();
    /// <summary>
    /// Constructs a new instance of <see cref="HashCounter{T}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    public HashCounter(ILogger logger) : this(logger, DefaultDictionary)
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
        if (!Contains(key))
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
    {
        foreach (KeyValuePair<T, int> pair in counter)
            yield return pair;
    }
    /// <summary>
    /// Creates a <see cref="CounterFactory{T}"/> for <see cref="HashCounter{T}"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="HashCounter(ILogger, IDictionary{T, int})" path="/param[@name='logger']"/></param>
    /// <param name="counter"><inheritdoc cref="HashCounter(ILogger, IDictionary{T, int})" path="/param[@name='counter']"/></param>
    /// <returns>A new <see cref="CounterFactory{T}"/> returning a <see cref="HashCounter{T}"/>.</returns>
    public static CounterFactory<T> Factory(ILogger logger, IDictionary<T, int> counter)
        => () => new HashCounter<T>(logger, counter);
    /// <summary>
    /// <inheritdoc cref="Factory(ILogger, IDictionary{T, int})" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="Factory(ILogger, IDictionary{T, int})" path="/param[@name='logger']"/></param>
    /// <returns><inheritdoc cref="Factory(ILogger, IDictionary{T, int})" path="/returns"/></returns>
    public static CounterFactory<T> Factory(ILogger logger)
        => Factory(logger, DefaultDictionary);
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
