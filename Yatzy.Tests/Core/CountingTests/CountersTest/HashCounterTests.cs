using Yatzy.Counting.Counters;

namespace Yatzy.Tests.Core.CountingTests.CountersTest;
public class HashCounterTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IDictionary<string, int>> counterMock;
    readonly HashCounter<string> systemUnderTest;
    public HashCounterTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        counterMock = new();
        systemUnderTest = new(loggerMock.Object, counterMock.Object);
    }
    [Fact]
    public void Count_NewKey_AddsKey()
    {
        int expected = HashCounter<string>.InitialCount;
        int actual = int.MinValue;
        counterMock
            .Setup(counter => counter.ContainsKey(It.IsAny<string>()))
            .Returns(false);
        counterMock
            .SetupSet(counter => counter[It.IsAny<string>()] = It.IsAny<int>())
            .Callback((string _, int initialValue) => actual = initialValue);
        systemUnderTest.Count(It.IsAny<string>());
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Count_KeyExising_IncrementsCount()
    {
        int current = 5;
        int expected = current + 1;
        int actual = int.MinValue;
        counterMock
            .Setup(counter => counter.ContainsKey(It.IsAny<string>()))
            .Returns(true);
        counterMock
            .Setup(counter => counter[It.IsAny<string>()])
            .Returns(current);
        counterMock
            .SetupSet(counter => counter[It.IsAny<string>()] = It.IsAny<int>())
            .Callback((string _, int incrementedCount) => actual = incrementedCount);
        systemUnderTest.Count(It.IsAny<string>());
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
}
