using Yatzy.Errors;

namespace Yatzy.Decoration;
/// <summary>
/// Defines extentions for wrapping.
/// </summary>
public static class WrapperExt
{
    /// <summary>
    /// Gets a context to wrap <typeparamref name="TDecorated"/> in a decorator.
    /// </summary>
    /// <typeparam name="TDecorated">The type being decorated.</typeparam>
    /// <param name="decorated">The decoratable value to wrap in a decorator.</param>
    /// <returns>A <see cref="WrapperContext{TAbstraction}"/> with <typeparamref name="TDecorated"/> instance as the context.</returns>
    /// <exception cref="NonAbstractionTypeParam{TGiven}"><inheritdoc cref="WrapperContext{TAbstraction}.WrapperContext()" path="/exception"/></exception>
    public static WrapperContext<TDecorated> WrapIn<TDecorated>(this TDecorated decorated)
        => new(decorated);
}
