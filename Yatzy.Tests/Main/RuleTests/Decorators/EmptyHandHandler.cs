using Yatzy.Dices;
using Yatzy.Rules;
using Yatzy.Rules.Decorators;

namespace Yatzy.Tests.Main.RuleTests.Decorators;
public class EmptyHandHandler
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IReadOnlyList<IDice>> handMock;
    readonly Mock<IRule<IDice>> ruleMock;
    readonly EmptyHandHandler<IDice> systemUnderTest;
    public EmptyHandHandler(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        handMock = new();
        ruleMock = new();
        ruleMock.Setup(rule => rule.LogType).Returns(ruleMock.Object.GetType());
        systemUnderTest = new(ruleMock.Object, loggerMock.Object);
    }
    [Fact]
    public void CalculatePoints_EmptyHand_LogsWarningReturnsZero()
    {
        loggerMock.Setup(logger => logger.Warning(It.IsAny<string>())).Verifiable();
        handMock.Setup(hand => hand.Count).Returns(0);
        Points expected = Points.Empty;
        Points actual = systemUnderTest.CalculatePoints(handMock.Object);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
        loggerMock.Verify(logger => logger.Warning(It.IsAny<string>()), Times.Once, "logger.Warning has not been called, or been called too many times.");
        output.WriteLine("Verified logger.Warning has been called.");
    }
    [Fact]
    public void CalculatePoints_NotEmptyHand_RunsWrapped()
    {
        handMock.Setup(hand => hand.Count).Returns(1);
        ruleMock.Setup(rule => rule.CalculatePoints(It.IsAny<IReadOnlyList<IDice>>())).Verifiable();
        systemUnderTest.CalculatePoints(handMock.Object);
        ruleMock.Verify(rule => rule.CalculatePoints(It.IsAny<IReadOnlyList<IDice>>()), Times.Once, "The wrapped.CalculatePoints has not been called.");
        output.WriteLine("Verified wrapped.CalculatePoints was called.");
    }
    [Fact]
    public void WrapInLogEmptyHand_Rule_WrapsRule()
    {
        IRule<IDice> wrapped = ruleMock.Object.WrapInLogEmptyHand(loggerMock.Object);
        bool actual = wrapped is EmptyHandHandler<IDice>;
        output.WriteExpectedTrue(actual);
        actual.Should().BeTrue();
    }
}