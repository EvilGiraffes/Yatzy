using Yatzy.Errors;

namespace Yatzy;
/// <summary>
/// Represents a builder, to build <typeparamref name="TBuilding"/>.
/// </summary>
/// <typeparam name="TBuilding">The type you want to build.</typeparam>
interface IBuilder<TBuilding>
{
    /// <summary>
    /// Builds an instance of <typeparamref name="TBuilding"/>.
    /// </summary>
    /// <returns>A new instance of <typeparamref name="TBuilding"/>.</returns>
    /// <exception cref="BuildingFailed">Thrown if the building did not succeed.</exception>
    TBuilding Build();
}
