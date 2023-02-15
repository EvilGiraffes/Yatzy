namespace Yatzy.UserInterface.CommandLine;
/// <summary>
/// Represents a way to interact with the console.
/// </summary>
public interface IConsoleProvider
{
    /// <inheritdoc cref="Console.BackgroundColor"/>
    ConsoleColor Background { get; set; }
    /// <inheritdoc cref="Console.ForegroundColor"/>
    ConsoleColor Foreground { get; set; }
    /// <inheritdoc cref="Console.WriteLine(string?)"/>
    /// <param name="message"><inheritdoc cref="Console.WriteLine(string?)" path="/param"/></param>
    void WriteLine(string? message);
    /// <inheritdoc cref="WriteLine(string?)"/>
    void WriteLine<T>(T? message);
    /// <inheritdoc cref="Console.Write(string?)"/>
    /// <param name="message"><inheritdoc cref="Console.Write(string?)" path="/param"/></param>
    void Write(string? message);
    /// <inheritdoc cref="Write(string?)"/>
    void Write<T>(T? message);
    /// <inheritdoc cref="Console.ReadLine"/>
    string? ReadLine();
    /// <inheritdoc cref="Console.ResetColor"/>
    void ResetColor();
}
