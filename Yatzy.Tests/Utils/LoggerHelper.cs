using Serilog.Events;
using Serilog.Exceptions;

namespace Yatzy.Tests.Utils;
public static class LoggerHelper
{

    public static ILogger GetTestOutputLogger<T>(ITestOutputHelper output)
    {
        ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Debug()
            .WriteTo.TestOutput(output)
            .Enrich.WithExceptionDetails()
            .CreateLogger()
            .ForContext<T>();
        return logger;
    }
    public static Mock<ILogger> GetLoggerMocked<T>(ITestOutputHelper output)
    {
        ILogger wrapped = GetTestOutputLogger<T>(output);
        Mock<ILogger> loggerMock = new();
        loggerMock
            .Setup(logger => logger.ForContext(It.IsAny<string>(), It.IsAny<object?>(), It.IsAny<bool>()))
            .Returns(loggerMock.Object);
        loggerMock
            .Setup(logger => logger.Write(It.IsAny<LogEvent>()))
            .Callback((LogEvent logEvent) => wrapped.Write(logEvent));
        return loggerMock;
    }
}
