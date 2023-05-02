using Yatzy.Tests.Writing.ResultFormatters;

namespace Yatzy.Tests.Writing.Writers;
public sealed class FormattedWriter : IWriter
{
    readonly ITestOutputHelper output;
    readonly IResultFormatter formatter;
    public FormattedWriter(ITestOutputHelper output, IResultFormatter formatter)
    {
        this.output = output;
        this.formatter = formatter;
    }
    public void WriteLine<T>(T expected, T actual)
        => output.WriteLine(formatter.Format(expected, actual));
}
