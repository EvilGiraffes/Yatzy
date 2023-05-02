using Yatzy.Tests.Writing.Writers;

namespace Yatzy.Tests.Writing.Factories.Writers;
public interface IWriterFactory
{
    IWriter Create(ITestOutputHelper output, string? seperator);
}
