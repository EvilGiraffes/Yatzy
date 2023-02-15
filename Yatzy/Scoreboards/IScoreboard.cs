using Yatzy.Observer;

namespace Yatzy.Scoreboards;
/// <summary>
/// Represents a scoreboard.
/// </summary>
/// <typeparam name="TEventArgs"><inheritdoc cref="ISubscriber{TEventArgs}" path="/typeparam"/></typeparam>
public interface IScoreboard<TEventArgs> : ISubscriber<TEventArgs>
    where TEventArgs : EventArgs
{
    /// <summary>
    /// Renders the scores into a formatted string.
    /// </summary>
    /// <returns>A formatted string.</returns>
    string RenderScores();
}
