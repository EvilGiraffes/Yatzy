namespace Yatzy.Tests.Utils.Callbacks;
public sealed class ListBasedCallback<T> : ICallback<T>
{
    public IReadOnlyList<T> Values
        => values.AsReadOnly();
    readonly List<T> values = new();

    public void Accept(T value)
        => values.Add(value);
}
