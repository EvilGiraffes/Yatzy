using Yatzy.Scoreboards;
using Yatzy.Scoreboards.Renderers;

namespace Yatzy.Tests.ScoreboardTests;
public class ScoreboardTests
{
    readonly ITestOutputHelper output;
    readonly Mock<ILogger> loggerMock;
    readonly Mock<IRenderer> rendererMock;
    readonly Mock<IDictionary<INameable, int>> scoresMock;
    readonly Mock<INameable> nameableMock;
    readonly YatzyScoreboard systemUnderTest;
    const string Name = "HelloWorld!";
    public ScoreboardTests(ITestOutputHelper output)
    {
        this.output = output;
        loggerMock = MockHelper.GetLogger();
        rendererMock = new();
        scoresMock = new();
        nameableMock = new();
        nameableMock.Setup(nameable => nameable.Name).Returns(Name);
        systemUnderTest = new(loggerMock.Object, rendererMock.Object, scoresMock.Object);
    }
    [Fact]
    public void SubscriberCallback_Null_DoesNotThrow()
    {
        Action nullArgs = () => systemUnderTest.SubscriberCallback(null);
        nullArgs.Should().NotThrow<NullReferenceException>();
    }
    [Fact]
    public void SubscriberCallback_NewPlayer_SetsPointRecieved()
    {
        int pointsRecieved = 5;
        int actual = 0;
        YatzyEventArgs args = new()
        {
            Player = nameableMock.Object,
            PointsRecieved = pointsRecieved,
        };
        scoresMock.Setup(scores => scores.ContainsKey(It.IsAny<INameable>())).Returns(false);
        scoresMock.SetupSet(scores => scores[It.IsAny<INameable>()] = It.IsAny<int>()).Callback((INameable _, int value) => actual = value);
        systemUnderTest.SubscriberCallback(args);
        output.WriteResult(pointsRecieved, actual);
        actual.Should().Be(pointsRecieved);
    }
    [Fact]
    public void SubscriberCallback_OldPlayer_UpdatesPlayer()
    {
        int pointsRecieved = 5;
        int pointsContained = 3;
        int expected = 5 + 3;
        int actual = 0;
        YatzyEventArgs args = new()
        {
            Player = nameableMock.Object,
            PointsRecieved = pointsRecieved
        };
        scoresMock.Setup(scores => scores.ContainsKey(It.IsAny<INameable>())).Returns(true);
        scoresMock.Setup(scores => scores[It.IsAny<INameable>()]).Returns(pointsContained);
        scoresMock.SetupSet(scores => scores[It.IsAny<INameable>()] = It.IsAny<int>()).Callback((INameable _, int value) => actual = value);
        systemUnderTest.SubscriberCallback(args);
        output.WriteResult(expected, actual);
        actual.Should().Be(expected);
    }
}
