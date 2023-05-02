using Yatzy.Tests.Writing.Factories.ResultFormatters;
using Yatzy.Tests.Writing.Factories.Writers;
using Yatzy.Tests.Writing.Writers;

namespace Yatzy.Tests.Writing;
public static class AttachWriterToOutput
{
    public static IWriterFactory WriterFactory { get; set; } = GetDefaultFactory();
    const string DefaultFormat = "Expected: {0}{1}Actual: {2}";
    public static IWriter Write(this ITestOutputHelper output, string? seperator = null)
        => WriterFactory.Create(output, seperator);
    public static IWriter Write<TSeperator>(this ITestOutputHelper output, TSeperator seperator)
        => Write(output, seperator?.ToString());
    static IWriterFactory GetDefaultFactory()
    {
        IResultFormatterFactory formatterFactory = new SeperatedFormatterFactory(DefaultFormat);
        return new FormattedWriterFactory(formatterFactory);
    }
}
