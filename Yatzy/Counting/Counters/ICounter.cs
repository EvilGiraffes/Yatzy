namespace Yatzy.Counting.Counters;
/// <summary>
/// Represents a counter.
/// </summary>
/// <typeparam name="T">The item its counting.</typeparam>
public interface ICounter<T> : IEnumerable<Count<T>>
    where T : notnull
{
    /// <inheritdoc cref="GetCount(T)"/>
    int this[T key]
        => GetCount(key);
    /// <summary>
    /// Count the item.
    /// </summary>
    /// <param name="key">The item to count.</param>
    void Count(T key);
    /// <summary>
    /// Gets the current count.
    /// </summary>
    /// <param name="key">Item to get the count from.</param>
    /// <returns>The count.</returns>
    int GetCount(T key);
    /// <summary>
    /// Indicates if the counter contains this item.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns><see langword="true"/> if it contains the key, <see langword="false"/> if it doesn't.</returns>
    bool Contains(T key);
    /// <summary>
    /// Clears all the items from the counter.
    /// </summary>
    void Clear();
}
