﻿namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents a strategy to splice the number.
/// </summary>
/// <seealso cref="TwoSplicedRule{TDice}"/>
public interface ISpliceStrategy
{
    /// <summary>
    /// Splices the number into a count of High and Low.
    /// </summary>
    /// <param name="count">The count to splice.</param>
    /// <returns>An instance of <see cref="Bounds"/> containing the splice.</returns>
    Bounds Splice(int count);
}
