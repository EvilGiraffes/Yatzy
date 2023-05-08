using System.Text;
using System.Text.Json;

namespace Yatzy.Errors;
// TESTME: Test message building is correct.
/// <summary>
/// Represents a <see cref="BuildingFailed"/> exception where the builder contained 1 or more <see langword="null"/> parameters, where they were required.
/// </summary>
public class BuildingContainedNullParameters : BuildingFailed
{
    /// <summary>
    /// The parameters which was <see langword="null"/>.
    /// </summary>
    public IEnumerable<string> Parameters { get; init; } = Enumerable.Empty<string>();
    /// <inheritdoc/>
    public override string Message
    {
        get
        {
            StringBuilder builder = new();
            builder
                .Append("The following parameters ")
                .Append(JsonSerializer.Serialize(Parameters))
                .Append(" was null. ")
                .Append(base.Message);
            return builder.ToString();
        }
    }
    /// <inheritdoc/>
    public BuildingContainedNullParameters()
    {
    }
    /// <inheritdoc/>
    public BuildingContainedNullParameters(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public BuildingContainedNullParameters(string message, Exception innerException) : base(message, innerException)
    {
    }
}
