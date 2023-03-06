using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Tests.Core.RuleTests.Strategies.Splicing;
public class FullHouseTest
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly FullHouse systemUnderTest;
    public FullHouseTest(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        systemUnderTest = new(loggerMock.Object);
    }
    [Fact]
    public void Splice_EvenCount_SplicedInMiddle()
    {
        Bounds expected = new(3, 3);
        Bounds actual = systemUnderTest.Splice(6);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Splice_OddCount_LowIsLowerHighIsHigher()
    {
        Bounds expected = new(2, 3);
        Bounds actual = systemUnderTest.Splice(5);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
}
