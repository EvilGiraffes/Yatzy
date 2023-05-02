namespace Yatzy.Counting.Counters;
// TODO: Use this in various places.
/// <summary>
/// Represents a factory to get a counter.
/// </summary>
/// <typeparam name="T"><inheritdoc cref="ICounter{T}" path="/typeparam"/></typeparam>
/// <returns>A new instance of an <see cref="ICounter{T}"/>.</returns>
public delegate ICounter<T> CounterFactory<T>()
    where T : notnull;