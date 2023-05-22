namespace Yatzy;
/// <summary>
/// Represents a function to transform <typeparamref name="TFrom"/> into <see cref="string"/>.
/// </summary>
/// <typeparam name="TFrom">The type to transform from.</typeparam>
/// <param name="from">The value to transform from.</param>
/// <returns>A new string representing <paramref name="from"/>.</returns>
public delegate string StringTransform<TFrom>(TFrom from);