namespace Yatzy.Tests.Writing;
public static class ExceptionWritingExt
{
    const string NoException = "No Exception";
    public static void ToThrow<TExpected>(this ExpectancyContext<Exception?> context)
        where TExpected : Exception
        => context.Output.WriteLine(
            typeof(TExpected).Name,
            NameOrNoException(context.Actual));
    public static void ToNotThrowException(this ExpectancyContext<Exception?> context)
        => context.Output.WriteLine(
            NoException,
            NameOrNoException(context.Actual));
    static string NameOrNoException(Exception? exception)
        => exception?.GetType().Name ?? NoException;
}
