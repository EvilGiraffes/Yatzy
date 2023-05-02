using Yatzy.Errors;

namespace Yatzy.Decoration;
/// <summary>
/// Defines extentions for wrapping.
/// </summary>
public static class WrapperExt
{
    /// <summary>
    /// Gets a context to wrap <typeparamref name="TDecoratable"/> in a decorator.
    /// </summary>
    /// <typeparam name="TDecoratable">The decoratable type to wrap it in.</typeparam>
    /// <param name="decoratable">The decoratable value to wrap in a decorator.</param>
    /// <returns>A <see cref="WrapperContext{TAbstraction}"/> with <typeparamref name="TDecoratable"/> instance as the context.</returns>
    /// <exception cref="NonAbstractionTypeParam{TGiven}"><inheritdoc cref="WrapperContext{TAbstraction}.WrapperContext()" path="/exception"/></exception>
    public static WrapperContext<TDecoratable> WrapIn<TDecoratable>(this TDecoratable decoratable)
        => decoratable;
}
