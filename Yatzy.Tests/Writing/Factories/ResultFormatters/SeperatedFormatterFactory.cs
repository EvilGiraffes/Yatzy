using Yatzy.Tests.Writing.ResultFormatters;

namespace Yatzy.Tests.Writing.Factories.ResultFormatters;
public sealed class SeperatedFormatterFactory : IResultFormatterFactory
{
    readonly string format;
    public SeperatedFormatterFactory(string format)
    {
        this.format = format;
    }
    public IResultFormatter Create(string? seperator)
        => new SeperatedFormatter(format, seperator);
}
