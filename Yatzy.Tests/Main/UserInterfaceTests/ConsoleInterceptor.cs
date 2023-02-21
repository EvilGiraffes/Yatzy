using Yatzy.UserInterface.CommandLine;

namespace Yatzy.Tests.Main.UserInterfaceTests;
public sealed class ConsoleInterceptor : IConsoleProvider
{
    public ConsoleColor Background { get; set; } = DefaultBackground;
    public ConsoleColor Foreground { get; set; } = DefaultForeground;
    public Results InterceptorResults
        => new()
        {
            Messages = messages,
            ColorReset = resetColorCalled,
            Background = Background,
            Foreground = Foreground,
        };
    bool resetColorCalled = false;
    readonly List<Message> messages = new();
    const ConsoleColor DefaultBackground = ConsoleColor.Black;
    const ConsoleColor DefaultForeground = ConsoleColor.Gray;

    public void ResetColor()
        => resetColorCalled = true;
    public void Write(string? message)
        => messages.Add(new Message { Msg = message });
    public void Write<T>(T? message)
        => messages.Add(new Message { Msg = message?.ToString() });
    public void WriteLine(string? message)
        => messages.Add(new Message { Msg = message, NewLine = true });
    public void WriteLine<T>(T? message)
        => messages.Add(new Message { Msg = message?.ToString(), NewLine = true });
    public string? ReadLine()
        => null;

    public record Message
    {
        public string? Msg { get; init; } = default!;
        public bool NewLine { get; init; } = false;
    }
    public record Results
    {
        public Message FirstResult
        {
            get
            {
                if (Messages.Count < 1)
                    throw new ArgumentOutOfRangeException(nameof(Messages), "Messages should have one result.");
                return Messages[0];
            }
        }
        public List<Message> Messages { get; init; } = new();
        public bool ColorReset { get; init; } = false;
        public ConsoleColor Background { get; init; }
        public ConsoleColor Foreground { get; init; }
    }
}
