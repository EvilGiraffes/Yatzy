namespace Yatzy.Tests.Writing;
public static class BooleanWritingExt
{
    public static void ToBeTrue(this ExpectancyContext<bool> context)
    => context.Output.WriteLine(true, context.Actual);
    public static void ToBeFalse(this ExpectancyContext<bool> context)
        => context.Output.WriteLine(false, context.Actual);
}
