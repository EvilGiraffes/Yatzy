namespace Yatzy.Tests.Writing;
public static class ObjectWritingExt
{
    const string Null = "null";
    public static void ToBe<T>(this ExpectancyContext<T> context, T expected)
        => context.Output.WriteLine(expected, context.Actual);
    public static void ToBeNull<T>(this ExpectancyContext<T> context)
    => context.Output.WriteLine(Null, TransformIfNull(context.Actual));
    static string TransformIfNull<T>(T value)
        => value?.ToString() ?? Null;
}
