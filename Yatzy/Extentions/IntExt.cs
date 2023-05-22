﻿namespace Yatzy.Extentions;
/// <summary>
/// A collection of extention methods for <see cref="int"/>.
/// </summary>
static class IntExt
{
    /// <summary>
    /// Verfies if <paramref name="x"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>.
    /// </summary>
    /// <param name="x">The value to check.</param>
    /// <param name="minimum">The defined minimum parameter.</param>
    /// <param name="maximum">The defined maximum parameter.</param>
    /// <returns><see langword="true"/> if it is in range, <see langword="false"/> if not.</returns>
    internal static bool InRange(this int x, int minimum, int maximum = int.MaxValue)
        => x >= minimum
        && x <= maximum;
    // TODO: Document.
    internal static void ThrowIfNot(this int x, Predicate<int> predicate, Func<Exception> thrownFactory, Action? failCallback = null)
    {
        if (predicate(x))
            return;
        failCallback?.Invoke();
        throw thrownFactory();
    }
}
