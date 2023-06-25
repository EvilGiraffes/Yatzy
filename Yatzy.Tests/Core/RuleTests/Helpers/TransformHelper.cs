namespace Yatzy.Tests.Core.RuleTests.Helpers;
public static class TransformHelper
{
    public static string SimpleTransform<T>(T obj)
        => obj?.ToString() ?? string.Empty;
}
