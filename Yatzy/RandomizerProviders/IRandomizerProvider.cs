namespace Yatzy.RandomizerProviders;
/// <summary>
/// Represents a provider for randomization.
/// </summary>
public interface IRandomizerProvider
{
    /// <inheritdoc cref="Random.Next(int, int)"/>
    /// <param name="min"><inheritdoc cref="Random.Next(int, int)" path="/param[@name='minValue']"/></param>
    /// <param name="max"><inheritdoc cref="Random.Next(int, int)" path="/param[@name='maxValue']"/></param>
    int Next(int min, int max);
}
