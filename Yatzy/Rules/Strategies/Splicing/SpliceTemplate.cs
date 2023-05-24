using Serilog;

using Yatzy.Errors;

namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents a <see cref="ISpliceStrategy"/> where the splicing is abstract.
/// </summary>
public abstract class SpliceTemplate : ISpliceStrategy
{
    /// <summary>
    /// The logger used throughout the application.
    /// </summary>
    protected ILogger Logger { get; }
    const int MinimumCount = 2;
    /// <summary>
    /// Creates a new <see cref="SpliceTemplate"/>.
    /// </summary>
    /// <param name="logger"><inheritdoc cref="Logger" path="/summary"/></param>
    protected SpliceTemplate(ILogger logger)
    {
        Logger = logger;
    }
    /// <inheritdoc/>
    public Bounds Splice(int count)
    {
        if (count < MinimumCount)
        {
            InvalidSpliceOperation exception = new($"Count cannot be under {MinimumCount}.");
            Logger.Error(exception, "The count {Count} was too low.", count);
            throw exception;
        }
        SpliceContext splice = DivideCount(count);
        Logger.Debug("Spliced it at {Splice}.", splice);
        return HandleSplicing(splice);
    }
    /// <summary>
    /// Divides the count in the favored way.
    /// </summary>
    /// <param name="count">The count to divide.</param>
    /// <returns><see cref="SpliceContext"/> representing the divition.</returns>
    protected abstract SpliceContext DivideCount(double count);
    /// <summary>
    /// Defines how the splice should be handled.
    /// </summary>
    /// <param name="context">The spliced context.</param>
    /// <returns><inheritdoc cref="Splice(int)" path="/returns"/></returns>
    protected abstract Bounds HandleSplicing(SpliceContext context);
    /// <summary>
    /// Represents the splice of the given count in the template method.
    /// </summary>
    protected readonly struct SpliceContext
    {
        /// <summary>
        /// The middle according to the splicing method.
        /// </summary>
        public double Splice { get; init; }
        /// <summary>
        /// The maximum count according to the splicing method.
        /// </summary>
        public double Max { get; init; }
        /// <summary>
        /// Checks if the <see cref="Max"/> is even.
        /// </summary>
        public bool IsEven
            => Max % 2 == 0;
        /// <summary>
        /// Will deconstruct the current <see cref="SpliceContext"/> into <paramref name="splice"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="splice"><inheritdoc cref="Splice" path="/summary"/></param>
        /// <param name="max"><inheritdoc cref="Max" path="/summary"/></param>
        public void Deconstruct(out double splice, out double max)
        {
            splice = Splice;
            max = Max;
        }
    }
}