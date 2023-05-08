using System.Text;

namespace Yatzy.Extentions;
/// <summary>
/// Contains extentions for <see cref="StringBuilder"/>.
/// </summary>
static class StringBuilderExt
{
    /// <summary>
    /// Will execute <see cref="StringBuilder.ToString()"/> and place it in the <paramref name="stringInsertionCallback"/>.
    /// </summary>
    /// <param name="builder">The builder to extract the <see cref="string"/> from.</param>
    /// <param name="stringInsertionCallback">A callback to insert the <see cref="string"/> from the <see cref="StringBuilder"/>.</param>
    internal static void ToString(this StringBuilder builder, Action<string> stringInsertionCallback)
        => stringInsertionCallback(builder.ToString());
}
