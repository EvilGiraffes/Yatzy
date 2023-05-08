namespace Yatzy.Errors;
/// <summary>
/// Represents an exception thrown when the building has been failed.
/// </summary>
public class BuildingFailed : Exception
{
    /// <inheritdoc/>
    public BuildingFailed()
    {
    }
    /// <inheritdoc/>
    public BuildingFailed(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public BuildingFailed(string message, Exception innerException) : base(message, innerException)
    {
    }
}
