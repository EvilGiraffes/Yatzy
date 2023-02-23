namespace Yatzy;
/// <summary>
/// Represents a decoratable type.
/// </summary>
public interface IDecoratable
{
    /// <summary>
    /// The inner type of the decoratable.
    /// </summary>
    Type LogType { get; }
}
