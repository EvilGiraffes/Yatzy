using Yatzy.Rules;

namespace Yatzy.Errors;
/// <summary>
/// Raised when the <see cref="XOfAKind{TDice}"/> count is out of bounds.
/// </summary>
public class XOfAKindOutOfRange : Exception
{
    /// <summary>
    /// The count given to the class.
    /// </summary>
    public int Given { get; init; }
    /// <summary>
    /// The minimum bound.
    /// </summary>
    public int Minimum { get; init; }
    /// <summary>
    /// The maximum bound.
    /// </summary>
    public int Maximum { get; init; }
    /// <inheritdoc/>
    public XOfAKindOutOfRange()
    {
    }
    /// <inheritdoc/>
    public XOfAKindOutOfRange(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public XOfAKindOutOfRange(string message, Exception innerException) : base(message, innerException)
    {
    }
}
