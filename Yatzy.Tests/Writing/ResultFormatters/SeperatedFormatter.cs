namespace Yatzy.Tests.Writing.ResultFormatters;
public sealed class SeperatedFormatter : IResultFormatter
{
    readonly string format;
    readonly string seperator;
    static readonly string Default = Environment.NewLine;

    public SeperatedFormatter(string format, string? seperator = null)
    {
        this.format = format;
        this.seperator = seperator ?? Default;
    }
    public string Format<T>(T expected, T actual)
        => string.Format(format, expected, seperator, actual);
}