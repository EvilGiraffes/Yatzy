namespace Yatzy.Tests.Writing.Writers;
public interface IWriter
{
    void WriteLine<T>(T expected, T actual);
}
