using Serilog.Exceptions;

namespace Yatzy.Tests;
public static class LoggerHelper
{
    const string Template = "[{Timestamp:HH:mm:ss} {Level:u3}] [{Test}] {Message:lj}{NewLine}{Exception}";
    public static ILogger GetTestOutputLogger<T>(ITestOutputHelper output)
    {
        ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Debug(outputTemplate: Template)
            .WriteTo.TestOutput(output, outputTemplate: Template)
            .Enrich.WithExceptionDetails()
            .CreateLogger()
            .ForContext("Test", typeof(T).Name);
        return logger;
    }
}
