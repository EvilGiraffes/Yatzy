using Yatzy.Dices;

namespace Yatzy.Tests.Main.RuleTests;
public static class RuleHelper
{
    public static IReadOnlyList<IDice> BuildHand(this Mock<IDice> diceMock, int count)
    {
        IDice[] hand = new IDice[count];
        for (int i = 0; i < count; i++)
            hand[i] = diceMock.Object;
        return hand;
    }
}
