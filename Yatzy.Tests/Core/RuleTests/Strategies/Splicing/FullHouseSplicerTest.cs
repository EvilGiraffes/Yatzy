using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Tests.Core.RuleTests.Strategies.Splicing;
public class FullHouseSplicerTest
{
    readonly ITestOutputHelper output;
    readonly FullHouseSplicer systemUnderTest;
    public FullHouseSplicerTest(ITestOutputHelper output)
    {
        this.output = output;
        ILogger logger = LoggerHelper.GetTestOutputLogger<FullHouseSplicerTest>(output);
        systemUnderTest = new(logger);
    }
    [Fact]
    public void Splice_EvenCount_SplicedInMiddle()
    {
        Bounds expected = new(3, 3);
        Bounds actual = systemUnderTest.Splice(6);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
    [Fact]
    public void Splice_OddCount_LowIsLowerHighIsHigher()
    {
        Bounds expected = new(2, 3);
        Bounds actual = systemUnderTest.Splice(5);
        output.Write().Expecting(actual).ToBe(expected);
        actual.Should().Be(expected);
    }
}
