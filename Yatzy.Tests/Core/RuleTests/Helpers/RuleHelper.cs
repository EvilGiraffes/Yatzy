using Yatzy.Dices;

namespace Yatzy.Tests.Core.RuleTests.Helpers;
public static class RuleHelper
{
    public static IReadOnlyList<IDice> EmptyHand
        => Array.Empty<IDice>();
    public static IReadOnlyList<IDice> AnyHand
        => EmptyHand;
    public static IReadOnlyList<IDice> BuildHand(this Mock<IDice> diceMock, int count = 5)
    {
        IDice[] hand = new IDice[count];
        for (int i = 0; i < count; i++)
            hand[i] = diceMock.Object;
        return hand;
    }
}
