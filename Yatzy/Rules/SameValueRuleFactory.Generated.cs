// This is a generated file!
// Do not manually modify as your changes will be overwritten.

using Serilog;

using Yatzy.Dices;
using Yatzy.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// A factory to create predetermined <see cref="SameValueRule{TDice}"/>.
/// </summary>
public static class SameValueRuleFactory
{
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Aces with the value of 1.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Aces<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Aces), 1, pointsCalculator);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Twos with the value of 2.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Twos<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Twos), 2, pointsCalculator);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Threes with the value of 3.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Threes<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Threes), 3, pointsCalculator);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fours with the value of 4.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fours<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Fours), 4, pointsCalculator);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fives with the value of 5.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fives<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Fives), 5, pointsCalculator);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Sixes with the value of 6.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Sixes<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Sixes), 6, pointsCalculator);
	}