namespace Yatzy;
/// <summary>
/// The event args used for a yatzee event.
/// </summary>
public sealed class YatzyEventArgs : EventArgs
{
    /// <summary>
    /// Player that got the points.
    /// </summary>
    public Player Player { get; init; } = default!;
    /// <summary>
    /// The amount of points the player recieved.
    /// </summary>
    public int PointsRecieved { get; init; }
}
