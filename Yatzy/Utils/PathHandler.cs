using System.Text;

namespace Yatzy.Utils;
/// <summary>
/// Handles the path for the configuration files.
/// </summary>
public static class PathHandler
{
    /// <summary>
    /// The configuration default name.
    /// </summary>
    public const string ConfigName = "Yatzy";
    /// <summary>
    /// The configuration extention.
    /// </summary>
    public const string ConfigExtention = ".config";
    /// <summary>
    /// Gets the config path from the given filename.
    /// </summary>
    /// <param name="filename">The name of the file to get the full path to.</param>
    /// <returns>The full path to the wanted file.</returns>
    public static string GetConfigPath(string filename)
    {
        StringBuilder builder = new();
        builder
            .Append(Directory.GetCurrentDirectory())
            .Append(Path.DirectorySeparatorChar)
            .Append("Config")
            .Append(Path.DirectorySeparatorChar)
            .Append(filename);
        string path = builder.ToString();
        return path;
    }
    /// <summary>
    /// Gets the filename based on the configuration type.
    /// </summary>
    /// <param name="configType">The configuration type to be inserted.</param>
    /// <returns>A properly formatted file name which consists of the config type.</returns>
    public static string GetFileName(string? configType = null)
    {
        if (configType is null)
            return $"{ConfigName}{ConfigExtention}";
        char seperator = '.';
        StringBuilder builder = new();
        builder
            .Append(ConfigName)
            .Append(seperator)
            .Append(configType)
            .Append(ConfigExtention);
        return builder.ToString();
    }
}
