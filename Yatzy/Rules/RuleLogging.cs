using Serilog;
using Serilog.Events;

using Yatzy.Dices;

namespace Yatzy.Rules;
// TODO: Document.
static class RuleLogging
{
    const string Applicable = "applicable";
    const string NotApplicable = "not " + Applicable;
    public static void LogSum(this ILogger logger, Points points, LogEventLevel level)
        => logger.Write(level, "The sum is {Points}.", points);
    public static void LogSumDebug(this ILogger logger, Points points)
        => LogSum(logger, points, LogEventLevel.Debug);
    public static void LogApplicable<TDice>(this ILogger logger, bool applicable, IReadOnlyList<TDice> hand, LogEventLevel level)
        where TDice : IDice
    {
        string applicability = applicable ? Applicable : NotApplicable;
        logger.Write(level, "The rule is {Applicability} for {Hand}.", applicability, hand);
    }
    public static void LogApplicableDebug<TDice>(this ILogger logger, bool applicable, IReadOnlyList<TDice> hand)
        where TDice : IDice
        => LogApplicable(logger, applicable, hand, LogEventLevel.Debug);
}
