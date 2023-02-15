using Serilog;

namespace Yatzy.UserInterface.CommandLine;
/// <summary>
/// Represents a command line interface to write and read from the console.
/// </summary>
public sealed class CommandLineInterface : IUserInterface<Message>
{
    readonly IConsoleProvider console;
    readonly ILogger logger;
    /// <summary>
    /// Constructs a new instance of the user interface.
    /// </summary>
    /// <param name="logger">The logger instance used throughout the application.</param>
    public CommandLineInterface(ILogger logger) : this(logger, null)
    {
    }
    /// <summary>
    /// <inheritdoc cref="CommandLineInterface.CommandLineInterface(ILogger)" path="/summary"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="CommandLineInterface.CommandLineInterface(ILogger)" path="/param[@name='logger']"/></param>
    /// <param name="console">A console provider to handle the different functionalities.</param>
    public CommandLineInterface(ILogger logger, IConsoleProvider? console)
    {
        this.logger = logger;
        console ??= new DefaultConsoleProvider();
        this.console = console;
    }
    /// <inheritdoc/>
    public void Display(Message entry)
    {
        console.Background = entry.Background;
        console.Foreground = entry.Foreground;
        logger.Debug("Background has been set to {Background}, Foreground has been set to {Foreground}.", entry.Background, entry.Foreground);
        Action<string> writer = GetWriter(entry.NewLine);
        try
        {
            if (entry.Content is null)
            {
                string message = "Content is null";
                logger.Error(message);
                throw new NullReferenceException(message);
            }
            logger.Debug("Writing content {Content}.", entry.Content);
            writer(entry.Content);
        }
        finally
        {
            logger.Debug("Resetting console color.");
            console.ResetColor();
        }
    }
    /// <inheritdoc/>
    public string? Input()
        => console.ReadLine();
    Action<string> GetWriter(bool newLine)
    {
        if (newLine)
            return console.WriteLine;
        return console.Write;
    }
}
