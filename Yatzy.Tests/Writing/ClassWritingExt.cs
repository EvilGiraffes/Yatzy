namespace Yatzy.Tests.Writing;
public static class ClassWritingExt
{
    const string Null = "null";
    public static void ToBeNull<T>(this ExpectancyContext<T> context)
    => context.Output.WriteLine(Null, TransformIfNull(context.Actual));
    static string TransformIfNull<T>(T value)
        => value?.ToString() ?? Null;
}
