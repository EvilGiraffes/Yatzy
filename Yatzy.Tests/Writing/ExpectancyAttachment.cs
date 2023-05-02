using Yatzy.Tests.Writing.Writers;

namespace Yatzy.Tests.Writing;
public static class ExpectancyAttachment
{
    public static ExpectancyContext<T> Expecting<T>(this IWriter output, T actual)
        => new()
        {
            Output = output,
            Actual = actual
        };
    public static ExpectancyContext<Exception?> Expecting(this IWriter output, Action act)
    {
        Exception? caughtException = null;
        try
        {
            act();
        }
        catch (Exception exception)
        {
            caughtException = exception;
        }
        return new()
        {
            Output = output,
            Actual = caughtException
        };
    }
}
