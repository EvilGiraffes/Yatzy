namespace Yatzy.Tests.Utils.Callbacks;
interface ICallback<T>
{
    IReadOnlyList<T> Values { get; }
    void Accept(T value);
}
