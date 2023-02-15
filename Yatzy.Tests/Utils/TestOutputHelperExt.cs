namespace Yatzy.Tests.Utils;
public static class TestOutputHelperExt
{
    public static string DefaultSeperator { get; set; } = "\n";
    public static void WriteResult<T>(this ITestOutputHelper output, T expected, T actual, string seperator)
        => output.WriteLine($"Expected: {expected}{seperator}Actual: {actual}");
    public static void WriteResult<T>(this ITestOutputHelper output, T expected, T actual)
        => WriteResult(output, expected, actual, DefaultSeperator);
    public static void WriteResult<T, TSeperator>(this ITestOutputHelper output, T expected, T actual, TSeperator seperator)
        where TSeperator : notnull
        => WriteResult(output, expected, actual, seperator.ToString() ?? DefaultSeperator);
    public static void WriteExpectedFalse(this ITestOutputHelper output, bool actual, string seperator)
        => WriteResult(output, false, actual, seperator);
    public static void WriteExpectedFalse(this ITestOutputHelper output, bool actual)
        => WriteResult(output, false, actual);
    public static void WriteExpectedFalse<TSeperator>(this ITestOutputHelper output, bool actual, TSeperator seperator)
        => WriteResult(output, false, actual);
    public static void WriteExpectedTrue(this ITestOutputHelper output, bool actual, string seperator)
        => WriteResult(output, true, actual, seperator);
    public static void WriteExpectedTrue(this ITestOutputHelper output, bool actual)
        => WriteResult(output, true, actual);
    public static void WriteExpectedTrue<TSeperator>(this ITestOutputHelper output, bool actual, TSeperator seperator)
        => WriteResult(output, true, actual);
}
