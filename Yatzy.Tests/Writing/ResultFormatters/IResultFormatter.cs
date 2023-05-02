namespace Yatzy.Tests.Writing.ResultFormatters;
public interface IResultFormatter
{
    string Format<T>(T expected, T actual);
}
