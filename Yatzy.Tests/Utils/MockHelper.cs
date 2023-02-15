using Moq;

using Serilog;

namespace Yatzy.Tests.Utils;
public static class MockHelper
{
    public static Mock<ILogger> GetLogger()
    {
        Mock<ILogger> logger = new();
        logger.Setup(logger => logger.ForContext(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<bool>())).Returns(logger.Object);
        logger.Setup(logger => logger.Verbose(It.IsAny<string>(), It.IsAny<object[]>()));
        logger.Setup(logger => logger.Debug(It.IsAny<string>(), It.IsAny<object[]>()));
        logger.Setup(logger => logger.Information(It.IsAny<string>(), It.IsAny<object[]>()));
        logger.Setup(logger => logger.Warning(It.IsAny<string>(), It.IsAny<object[]>()));
        logger.Setup(logger => logger.Error(It.IsAny<string>(), It.IsAny<object[]>()));
        logger.Setup(logger => logger.Fatal(It.IsAny<string>(), It.IsAny<object[]>()));
        return logger;
    }
}
