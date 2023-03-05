namespace Yatzy.Errors;
/// <summary>
/// Thrown when the splicing operation is not allowed.
/// </summary>
public class InvalidSpliceOperation : Exception
{
    /// <inheritdoc/>
    public InvalidSpliceOperation()
    {
    }
    /// <inheritdoc/>

    public InvalidSpliceOperation(string message) : base(message)
    {
    }
    /// <inheritdoc/>

    public InvalidSpliceOperation(string message, Exception innerException) : base(message, innerException)
    {
    }
}
