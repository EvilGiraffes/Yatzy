namespace Yatzy.UserInterface.CommandLine;
/// <summary>
/// Represents an entry for a <see cref="CommandLineInterface"/> instance.
/// </summary>
public sealed class Message
{
    /// <summary>
    /// The content to display in the message.
    /// </summary>
    public string Content { get; init; } = default!;
    /// <summary>
    /// If it should be written as a new line of not.
    /// </summary>
    public bool NewLine { get; init; } = false;
    /// <summary>
    /// The background to use for the message. The default is black.
    /// </summary>
    public ConsoleColor Background { get; init; } = ConsoleColor.Black;
    /// <summary>
    /// The foreground to use for the message. The default is gray.
    /// </summary>
    public ConsoleColor Foreground { get; init; } = ConsoleColor.Gray;
}
