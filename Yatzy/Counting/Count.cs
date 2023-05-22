namespace Yatzy.Counting;
/// <summary>
/// Represents a count.
/// </summary>
/// <typeparam name="T">The item its counting.</typeparam>
public readonly struct Count<T>
    where T : notnull
{

    /// <summary>
    /// The item that has been counted.
    /// </summary>
    public T Item { get; init; }
    /// <summary>
    /// The current count it has.
    /// </summary>
    public int Amount { get; init; }
    /// <summary>
    /// Constructs a new instance of <see cref="Count{T}"/>.
    /// </summary>
    /// <param name="item">The item it has counted.</param>
    /// <param name="amount">The count it has.</param>
    public Count(T item, int amount) : this()
    {
        Item = item;
        Amount = amount;
    }
    /// <inheritdoc/>
    public override int GetHashCode()
        => Item.GetHashCode();
    /// <summary>
    /// Will deconstruct the item into its contained memebers.
    /// </summary>
    /// <param name="item">The item it has counted.</param>
    /// <param name="amount">The count it has.</param>
    public void Deconstruct(out T item, out int amount)
    {
        item = Item;
        amount = Amount;
    }
    /// <summary>
    /// Creates a <see cref="Count{T}"/> from a <see cref="KeyValuePair{TKey, TValue}"/>.
    /// </summary>
    /// <param name="pair">The <see cref="KeyValuePair{TKey, TValue}"/> to convert from.</param>
    public static implicit operator Count<T>(KeyValuePair<T, int> pair)
        => new(pair.Key, pair.Value);
}
