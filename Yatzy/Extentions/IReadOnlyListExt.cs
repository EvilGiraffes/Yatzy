namespace Yatzy.Extentions;
static class IReadOnlyListExt
{
    internal static bool IsEmpty<T>(this IReadOnlyList<T> list)
        => list.Count < 1;
}
