using Serilog;

using Yatzy.Extentions;
using Yatzy.Logging;
using Yatzy.Rules;

namespace Yatzy.Errors;
/// <summary>
/// Raised when the <see cref="XOfAKind{TDice}"/> count is out of bounds.
/// </summary>
public class XOutOfRange : Exception
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
    const string InternalTemplate = "The value {X} was not within the range {Minimum}-{Maximum}.";
    /// <inheritdoc/>
    public XOutOfRange()
    {
    }
    /// <inheritdoc/>
    public XOutOfRange(string message) : base(message)
    {
    }
    /// <inheritdoc/>
    public XOutOfRange(string message, Exception innerException) : base(message, innerException)
    {
    }
    /// <summary>
    /// Will guard against <paramref name="x"/> being out of range.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <param name="x">The value to be guarded.</param>
    /// <param name="minimum">The minimum inclusive bound it can be in.</param>
    /// <param name="maximum">The maximum inclusive bound it can be in.</param>
    public static void Guard(ILogger logger, int x, int minimum, int maximum)
    {
        if (x.InRange(minimum, maximum))
            return;
        LogTemplate template = Template(x, minimum, maximum);
        logger.Error(template);
        throw new XOutOfRange
        {
            Given = x,
            Minimum = minimum,
            Maximum = maximum
        };
    }
    static LogTemplate Template(int given, int minimum, int maximum = int.MaxValue)
        => new(InternalTemplate, new object[] { given, minimum, maximum });
    int Difference()
    {
        if (Given < Minimum)
            return Given - Minimum;
        return Given - Maximum;
    }
}
