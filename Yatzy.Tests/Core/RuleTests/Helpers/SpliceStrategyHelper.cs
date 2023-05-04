using Yatzy.Rules.Strategies.Splicing;

namespace Yatzy.Tests.Core.RuleTests.Helpers;

public static class SpliceStrategyHelper
{
    public static void SpliceReturns(this Mock<ISpliceStrategy> spliceMock, Bounds bounds)
        => spliceMock.Setup(splicer => splicer.Splice(It.IsAny<int>())).Returns(bounds);
}