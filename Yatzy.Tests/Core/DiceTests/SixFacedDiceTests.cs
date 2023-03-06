using Yatzy.Dices;
using Yatzy.Dices.States;
using Yatzy.Errors;

namespace Yatzy.Tests.Core.DiceTests;
public class SixFacedDiceTests
{
    readonly Mock<IDiceState> stateMock;
    readonly Mock<ILogger> loggerMock;
    readonly SixFacedDice systemUnderTest;
    const int PropertyRuns = 10000;
    readonly DiceRange range;
    int StartValue
        => range.MinimumFace;
    int RangeDifference
        => range.MaximumFace - range.MinimumFace;
    public SixFacedDiceTests()
    {
        stateMock = new();
        loggerMock = MockHelper.GetLogger();
        range = SixFacedDice.Range;
        systemUnderTest = new(loggerMock.Object, stateMock.Object, StartValue);
    }
    [Fact]
    public void Roll_PropertyTestFace()
    {

        for (int i = 0; i < PropertyRuns; i++)
        {
            int alteringValue = 5;
            Func<int> returnInterceptor = ToggleInterceptor(systemUnderTest, alteringValue);
            stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(() => returnInterceptor());
            // Adds altering value.
            systemUnderTest.Roll();
            // Subtracts altering value.
            systemUnderTest.Roll();
            systemUnderTest.Face.Should().Be(StartValue);
        }
    }
    [Fact]
    public void Roll_ChangesFace()
    {
        int expected = RangeDifference / 2 + range.MinimumFace;
        stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(expected);
        systemUnderTest.Roll();
        systemUnderTest.Face.Should().Be(expected);
    }
    [Fact]
    public void FaceSet_TooSmall_ThrowsException()
    {
        stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(range.MinimumFace - 1);
        Action faultyMethod = systemUnderTest.Roll;
        faultyMethod.Should().Throw<DiceFaceOutOfRange>();
    }
    [Fact]
    public void FaceSet_TooLarge_ThrowsException()
    {
        stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(range.MaximumFace + 1);
        Action faultyMethod = systemUnderTest.Roll;
        faultyMethod.Should().Throw<DiceFaceOutOfRange>();
    }
    [Fact]
    public void FaceSet_LowerEdge_DoesNotThrowException()
    {
        stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(range.MinimumFace);
        Action method = systemUnderTest.Roll;
        method.Should().NotThrow<DiceFaceOutOfRange>();
    }
    [Fact]
    public void FaceSet_UpperEdge_DoesNotThrowException()
    {
        stateMock.Setup(state => state.Roll(It.IsAny<IDice>(), It.IsAny<DiceRange>())).Returns(range.MaximumFace);
        Action method = systemUnderTest.Roll;
        method.Should().NotThrow<DiceFaceOutOfRange>();
    }
    static Func<int> ToggleInterceptor(SixFacedDice dice, int alteringValue)
    {
        int index = 0;
        Func<int, int>[] operations = new Func<int, int>[]
        {
            number => number + alteringValue,
            number => number - alteringValue
        };
        return () =>
        {
            int result = operations[index](dice.Face);
            index = (index + 1) % operations.Length;
            return result;
        };
    }
}
