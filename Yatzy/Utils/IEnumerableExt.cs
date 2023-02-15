namespace Yatzy.Utils;
/// <summary>
/// Contains extentions for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class IEnumerableExt
{
    /// <summary>
    /// Will call the following action on all the values contained.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="IEnumerable{T}" path="/typeparam"/></typeparam>
    /// <param name="items">The items to enumerate over.</param>
    /// <param name="action">The action to perform on each item.</param>
    public static void Call<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T value in items)
            action(value);
    }
}
