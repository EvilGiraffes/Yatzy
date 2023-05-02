namespace Yatzy.Extentions;
/// <summary>
/// Contains extentions for <see cref="IEnumerable{T}"/>.
/// </summary>
static class IEnumerableExt
{
    /// <summary>
    /// Will pipe all the <typeparamref name="T"/> values into the <see cref="Action{T}"/>.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="IEnumerable{T}" path="/typeparam"/></typeparam>
    /// <param name="items">The items to enumerate over.</param>
    /// <param name="action">The action to perform on each item.</param>
    internal static void Pipe<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T value in items)
            action(value);
    }
}
