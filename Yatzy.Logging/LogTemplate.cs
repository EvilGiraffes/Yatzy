namespace Yatzy.Logging;
/// <summary>
/// Represents a template for logging.
/// </summary>
public sealed record LogTemplate
(
    string Template,
    object?[]? Args
);
