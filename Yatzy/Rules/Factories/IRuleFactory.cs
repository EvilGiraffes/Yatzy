using Serilog;

using Yatzy.Dices;

namespace Yatzy.Rules.Factories;
/// <summary>
/// Defines a factory to create a <see cref="IRule{TDice}"/>.
/// </summary>
/// <typeparam name="TDice">The type of dice which this factory should create rules for.</typeparam>
public interface IRuleFactory<TDice>
    where TDice : IDice
{
    /// <summary>
    /// Creates a new instance of an <see cref="IRule{TDice}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application.</param>
    /// <returns>A new <see cref="IRule{TDice}"/>.</returns>
    IRule<TDice> Create(ILogger logger);
}
