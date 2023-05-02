namespace Yatzy;
/// <summary>
/// Represents a type who has a name.
/// </summary>
public interface INameable
{
    /// <summary>
    /// The name of this type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is expected to use PascalCasing.<br/>
    /// This way a formatter would easier be able to format the name if desired.
    /// </para>
    /// <para>
    /// Reason for using PascalCase is due to the convention of the C# language's classes, thereby one can easily use nameof().
    /// </para>
    /// </remarks>
    string Name { get; }
}
