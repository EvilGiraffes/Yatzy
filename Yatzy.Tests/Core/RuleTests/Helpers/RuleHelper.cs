using Yatzy.Dices;

namespace Yatzy.Tests.Core.RuleTests.Helpers;
public static class RuleHelper
{
    public static IReadOnlyCollection<IDice> EmptyHand
        => Array.Empty<IDice>();
    public static IReadOnlyCollection<IDice> AnyHand
        => EmptyHand;
    public static IReadOnlyCollection<IDice> BuildHand(this Mock<IDice> diceMock, int count = 5)
    {
        IDice[] hand = new IDice[count];
        for (int i = 0; i < count; i++)
            hand[i] = diceMock.Object;
        return hand;
    }
}
