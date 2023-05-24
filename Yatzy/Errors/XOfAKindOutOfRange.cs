using Yatzy.Rules;

namespace Yatzy.Errors;
/// <summary>
/// Raised when the <see cref="XOfAKind{TDice}"/> count is out of bounds.
/// </summary>
public class XOfAKindOutOfRange : Exception
{
    /// <inheritdoc/>
    public override string Message
        => $"{base.Message} It is out of range by {Difference()}.";
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
    int Difference()
    {
        if (Given < Minimum)
            return Given - Minimum;
        return Given - Maximum;
    }
}
