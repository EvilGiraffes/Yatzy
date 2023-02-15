namespace Yatzy;
/// <summary>
/// Represents a player.
/// </summary>
public sealed record Player : INameable
{
    /// <inheritdoc/>
    public string Name { get; init; } = default!;
}
