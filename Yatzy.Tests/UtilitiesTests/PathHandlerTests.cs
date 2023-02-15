

using Yatzy.Utils;

namespace Yatzy.Tests.UtilitiesTests;

public class PathHandlerTests
{
    readonly ITestOutputHelper output;
    public PathHandlerTests(ITestOutputHelper output)
    {
        this.output = output;
    }
    [Fact]
    public void GetFileName_NullParameter_ReturnsConfigNameAndExt()
    {
        string expected = PathHandler.ConfigName + PathHandler.ConfigExtention;
        string actual = PathHandler.GetFileName(null);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void GetFileName_ConfigType_ReturnsPathWithConfigType()
    {
        const string configType = "Testing";
        string expected = $"{PathHandler.ConfigName}.{configType}{PathHandler.ConfigExtention}";
        string actual = PathHandler.GetFileName(configType);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
    [Fact]
    public void GetConfigPath_ReturnsExpectedPath()
    {
        const string fileName = "Testing.txt";
        string expected = $@"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Config{Path.DirectorySeparatorChar}{fileName}";
        string actual = PathHandler.GetConfigPath(fileName);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
}