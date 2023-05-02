namespace Yatzy.Tests.Writing;
public static class PointsWritingExt
{
    public static void ToBeEmpty(this ExpectancyContext<Points> context)
    => context.Output.WriteLine(Points.Empty, context.Actual);
}
