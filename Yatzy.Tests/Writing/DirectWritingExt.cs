namespace Yatzy.Tests.Writing;
public static class DirectWritingExt
{
    public static void ToBe<T>(this ExpectancyContext<T> context, T expected)
        => context.Output.WriteLine(expected, context.Actual);
}
