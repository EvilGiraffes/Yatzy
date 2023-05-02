using Yatzy.Tests.Writing.Factories.ResultFormatters;
using Yatzy.Tests.Writing.Writers;

namespace Yatzy.Tests.Writing.Factories.Writers;
public sealed class FormattedWriterFactory : IWriterFactory
{
    readonly IResultFormatterFactory formatterFactory;
    public FormattedWriterFactory(IResultFormatterFactory formatterFactory)
    {
        this.formatterFactory = formatterFactory;
    }
    public IWriter Create(ITestOutputHelper output, string? seperator)
        => new FormattedWriter(output, formatterFactory.Create(seperator));
}
