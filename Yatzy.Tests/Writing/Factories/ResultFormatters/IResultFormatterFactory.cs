using Yatzy.Tests.Writing.ResultFormatters;

namespace Yatzy.Tests.Writing.Factories.ResultFormatters;
public interface IResultFormatterFactory
{
    IResultFormatter Create(string? seperator);
}
