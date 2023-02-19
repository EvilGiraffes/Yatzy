namespace Yatzy.Scoreboards.Renderers;
/// <summary>
/// Represents a type who can render a representation of a scoreboard to the screen.
/// </summary>
public interface IRenderer
{
    /// <summary>
    /// Renders a representation of the scoreboard.
    /// </summary>
    /// <param name="scoreboard">The scoreboard to render.</param>
    /// <returns>The formatted string.</returns>
    string Render(IDictionary<INameable, int> scoreboard);
}
