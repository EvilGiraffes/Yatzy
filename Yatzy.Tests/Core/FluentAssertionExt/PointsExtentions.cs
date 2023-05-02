namespace Yatzy.Tests.Core.FluentAssertionExt;
public static class PointsExtentions
{
    public static PointsAssertions Should(this Points instance)
        => new(instance);
}
