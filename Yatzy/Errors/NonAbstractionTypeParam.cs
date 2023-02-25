namespace Yatzy.Errors;

/// <summary>
/// Thrown when the type parameter was expected to be an abstraction.
/// </summary>
/// <remarks>
/// Abstractions include Abstract Class and Interface.
/// </remarks>
/// <typeparam name="TGiven">The given value.</typeparam>
public class NonAbstractionTypeParam<TGiven> : Exception
{
    /// <summary>
    /// The value that was given
    /// </summary>
    public Type Given
        => typeof(TGiven);
    /// <inheritdoc/>
    public NonAbstractionTypeParam()
    {
    }
    /// <inheritdoc/>
    public NonAbstractionTypeParam(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public NonAbstractionTypeParam(string message, Exception innerException) : base(message, innerException)
    {
    }
}
