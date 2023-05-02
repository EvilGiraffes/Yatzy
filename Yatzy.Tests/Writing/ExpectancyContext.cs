using Yatzy.Tests.Writing.Writers;

namespace Yatzy.Tests.Writing;
public readonly struct ExpectancyContext<T>
{
    public IWriter Output { get; init; }
    public T Actual { get; init; }
}
