namespace Yatzy.Decoration;
/// <summary>
/// Represents a logging wrappable type for extentions to logging on behalf of the object.
/// </summary>
public interface ILogWrappable
{
    /// <summary>
    /// The inner type of the decoratable.
    /// </summary>
    /// <remarks>If the class is a decorator this should be implemented and point to the next values <see cref="WrappedLogType"/>.</remarks>
    Type WrappedLogType
        => GetType();
}
