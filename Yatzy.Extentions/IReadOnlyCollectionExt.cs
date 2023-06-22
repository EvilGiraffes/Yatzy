namespace Yatzy.Extentions;
/// <summary>
/// Represents extentions for <see cref="IReadOnlyList{T}"/>.
/// </summary>
public static class IReadOnlyCollectionExt
{
    /// <summary>
    /// Checks if the current list is empty.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="IReadOnlyList{T}" path="/typeparam"/></typeparam>
    /// <param name="list">The list to check.</param>
    /// <returns><see langword="true"/> if it is empty, <see langword="false"/> if not.</returns>
    public static bool IsEmpty<T>(this IReadOnlyCollection<T> list)
        => list.Count < 1;
}
