namespace Yatzy.Errors;
/// <summary>
/// Represents a an exception thrown when the constructor argument passed to <see cref="Bounds"/> is invalid.
/// </summary>
public class BoundsInvalidConstructorArgument : ArgumentException
{
    /// <summary>
    /// The low value attempted to set.
    /// </summary>
    public int Low { get; init; }
    /// <summary>
    /// The high value attempted to set.
    /// </summary>
    public int High { get; init; }
    /// <summary>
    /// Creates a new instance of <see cref="BoundsInvalidConstructorArgument"/>.
    /// </summary>
    public BoundsInvalidConstructorArgument()
    {
    }
    /// <summary>
    /// <inheritdoc cref="BoundsInvalidConstructorArgument()" path="/summary"/>
    /// </summary>
    /// <param name="message"><inheritdoc cref="ArgumentException(string)" path="/param[@name='message']"/></param>
    public BoundsInvalidConstructorArgument(string message) : base(message)
    {
    }
    /// <summary>
    /// <inheritdoc cref="BoundsInvalidConstructorArgument()" path="/summary"/>
    /// </summary>
    /// <param name="message"><inheritdoc cref="ArgumentException(string, Exception)" path="/param[@name='message']"/></param>
    /// <param name="innerException"><inheritdoc cref="ArgumentException(string, Exception)" path="/param[@name='innerException']"/></param>
    public BoundsInvalidConstructorArgument(string message, Exception innerException) : base(message, innerException)
    {
    }
    /// <summary>
    /// <inheritdoc cref="BoundsInvalidConstructorArgument()" path="/summary"/>
    /// </summary>
    /// <param name="message"><inheritdoc cref="ArgumentException(string, string)" path="/param[@name='message']"/></param>
    /// <param name="paramName"><inheritdoc cref="ArgumentException(string, string)" path="/param[@name='paramName']"/></param>
    public BoundsInvalidConstructorArgument(string message, string paramName) : base(message, paramName)
    {
    }
    /// <summary>
    /// <inheritdoc cref="BoundsInvalidConstructorArgument()" path="/summary"/>
    /// </summary>
    /// <param name="message"><inheritdoc cref="ArgumentException(string, string, Exception)" path="/param[@name='message']"/></param>
    /// <param name="paramName"><inheritdoc cref="ArgumentException(string, string, Exception)" path="/param[@name='paramName']"/></param>
    /// <param name="innerException"><inheritdoc cref="ArgumentException(string, string, Exception)" path="/param[@name='innerException']"/></param>
    public BoundsInvalidConstructorArgument(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
    {
    }
}
