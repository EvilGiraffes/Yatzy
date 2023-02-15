using Yatzy.UserInterface.CommandLine;

namespace Yatzy.Tests.UserInterfaceTests;
// TODO: Use mock instead of an interceptor.
public class CommandLineInterfaceTests
{
    readonly ITestOutputHelper output;
    readonly CommandLineInterface systemUnderTest;
    readonly Mock<ILogger> loggerMock;
    readonly ConsoleInterceptor interceptor;
    const string TestingMessage = "Testing";
    public CommandLineInterfaceTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        interceptor = new ConsoleInterceptor();
        systemUnderTest = new(loggerMock.Object, interceptor);
    }
    [Fact]
    public void Display_Content_MatchesExpected()
    {
        Message message = new()
        {
            Content = TestingMessage
        };
        systemUnderTest.Display(message);
        ConsoleInterceptor.Results results = interceptor.InterceptorResults;
        output.WriteResult(TestingMessage, results.FirstResult.Msg);
        results.FirstResult.Msg.Should().Be(TestingMessage);
    }
    [Fact]
    public void Display_NoNewLine_WritesWithoutNewline()
    {
        Message message = new()
        {
            Content = TestingMessage,
            NewLine = false
        };
        systemUnderTest.Display(message);
        ConsoleInterceptor.Results results = interceptor.InterceptorResults;
        output.WriteExpectedFalse(results.FirstResult.NewLine);
        results.FirstResult.NewLine.Should().BeFalse();
    }
    [Fact]
    public void Display_NewLine_WritesWithNewLine()
    {
        Message message = new()
        {
            Content = TestingMessage,
            NewLine = true
        };
        systemUnderTest.Display(message);
        ConsoleInterceptor.Results results = interceptor.InterceptorResults;
        output.WriteExpectedTrue(results.FirstResult.NewLine);
        results.FirstResult.NewLine.Should().BeTrue();
    }
    [Fact]
    public void Display_BackgroundAndForeground_ChangesColor()
    {
        ConsoleColor expectedBackground = ConsoleColor.Green;
        ConsoleColor expectedForeground = ConsoleColor.Cyan;
        Message message = new()
        {
            Content = TestingMessage,
            Background = expectedBackground,
            Foreground = expectedForeground
        };
        systemUnderTest.Display(message);
        ConsoleInterceptor.Results results = interceptor.InterceptorResults;
        output.WriteLine("Background:");
        output.WriteResult(expectedBackground, results.Background);
        results.Background.Should().Be(expectedBackground);
        output.WriteLine("Foreground:");
        output.WriteResult(expectedForeground, results.Foreground);
        results.Foreground.Should().Be(expectedForeground);
    }
    [Fact]
    public void Display_Exception_ResetsColor()
    {
        Message faultyMessage = new();
        try
        {
            systemUnderTest.Display(faultyMessage);
        }
        catch (NullReferenceException) { }
        ConsoleInterceptor.Results results = interceptor.InterceptorResults;
        output.WriteExpectedTrue(results.ColorReset);
        results.ColorReset.Should().BeTrue();
    }
    [Fact]
    public void Display_NoContent_ShouldThrowNullReferenceException()
    {
        Message faultyMessage = new();
        Action faultyDisplay = () => systemUnderTest.Display(faultyMessage);
        faultyDisplay.Should().Throw<NullReferenceException>();
    }
}
