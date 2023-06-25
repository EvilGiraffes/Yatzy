using Yatzy.Decoration;

namespace Yatzy.Rules.Strategies.Splicing;
/// <summary>
/// Represents an <see cref="ISpliceStrategy"/> decorator which modifies the count given to the next splice with the given modifier.
/// </summary>
public sealed class SplicerCountModifier : ISpliceStrategy
{
    readonly ISpliceStrategy wrapped;
    readonly Func<int, int> modifer;
    /// <summary>
    /// Constructs a new <see cref="SplicerCountModifier"/>.
    /// </summary>
    /// <param name="wrapped">The next splicer in line.</param>
    /// <param name="modifer">The modifier to use on the count.</param>
    public SplicerCountModifier(ISpliceStrategy wrapped, Func<int, int> modifer)
    {
        this.wrapped = wrapped;
        this.modifer = modifer;
    }
    /// <inheritdoc/>
    public Bounds Splice(int count)
        => wrapped.Splice(
            modifer(count));
}
/// <summary>
/// Represents a wrapper extention to wrap an <see cref="ISpliceStrategy"/> in a <see cref="Splicing.SplicerCountModifier"/>.
/// </summary>
public static class SplicerCountModifierWrapper
{
    /// <summary>
    /// Wraps the current <see cref="ISpliceStrategy"/> in <see cref="Splicing.SplicerCountModifier"/>.
    /// </summary>
    /// <param name="wrapped">The <see cref="ISpliceStrategy"/> to wrap.</param>
    /// <param name="modifer">The modifer to use.</param>
    /// <returns>a new <see cref="ISpliceStrategy"/>.</returns>
    public static ISpliceStrategy SplicerCountModifier(this WrapperContext<ISpliceStrategy> wrapped, Func<int, int> modifer)
        => new SplicerCountModifier(wrapped.Context, modifer);
}