using Yatzy.Errors;

namespace Yatzy.Decoration;
/// <summary>
/// Represents the context of of wrapping.
/// </summary>
/// <remarks>
/// This type is meant to be extended for decorators to add their own wrapping.
/// </remarks>
/// <typeparam name="TAbstraction">The abstract type context.</typeparam>
public readonly struct WrapperContext<TAbstraction>
{
    /// <summary>
    /// The context to wrap in.
    /// </summary>
    public TAbstraction Context { get; init; }
    /// <summary>
    /// Creates a default instance of the wrapper context.
    /// </summary>
    /// <exception cref="NonAbstractionTypeParam{TGiven}">Thrown if the type isnt abstract or an interface.</exception>
    public WrapperContext()
    {
        Type abstraction = typeof(TAbstraction);
        if (!abstraction.IsInterface && !abstraction.IsAbstract)
            throw new NonAbstractionTypeParam<TAbstraction>();
        Context = default!;
    }
    /// <summary>
    /// <inheritdoc cref="WrapperContext()" path="/summary"/>
    /// </summary>
    /// <param name="context">The context it should give further.</param>
    /// <exception cref="NonAbstractionTypeParam{TGiven}"><inheritdoc cref="WrapperContext()" path="/exception"/></exception>
    public WrapperContext(TAbstraction context) : this()
    {
        Context = context;
    }
    /// <summary>
    /// Converts the current type into a wrapper with that type.
    /// </summary>
    /// <param name="context">The context to convert from.</param>
    public static implicit operator WrapperContext<TAbstraction>(TAbstraction context)
        => new(context);
}
