namespace Yatzy.UserInterface.CommandLine;
/// <summary>
/// Represents the defaul way of interacting with the console.
/// </summary>
public sealed class DefaultConsoleProvider : IConsoleProvider
{
    /// <inheritdoc/>
    public ConsoleColor Background
    {
        get => Console.BackgroundColor;
        set => Console.BackgroundColor = value;
    }
    /// <inheritdoc/>
    public ConsoleColor Foreground
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }
    /// <inheritdoc/>
    public void Write(string? message)
        => Console.Write(message);
    /// <inheritdoc/>
    public void Write<T>(T? message)
        => Console.Write(message?.ToString());
    /// <inheritdoc/>
    public void WriteLine(string? message)
        => Console.WriteLine(message);
    /// <inheritdoc/>
    public void WriteLine<T>(T? message)
        => Console.WriteLine(message?.ToString());
    /// <inheritdoc/>
    public string? ReadLine()
        => Console.ReadLine();
    /// <inheritdoc/>
    public void ResetColor()
        => Console.ResetColor();
}
