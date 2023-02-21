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
	
	// Generated Method Aces.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Aces with the value of 1.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Aces<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Aces), 1, pointsCalculator);
	
	// Generated Override for Method Aces.

	/// <summary>
	/// <inheritdoc cref="Aces{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Aces{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Aces<TDice>(ILogger logger)
		where TDice : IDice
		=> Aces<TDice>(logger, new FaceBasedCalculation());
	
	// Generated Method Twos.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Twos with the value of 2.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Twos<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Twos), 2, pointsCalculator);
	
	// Generated Override for Method Twos.

	/// <summary>
	/// <inheritdoc cref="Twos{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Twos{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Twos<TDice>(ILogger logger)
		where TDice : IDice
		=> Twos<TDice>(logger, new FaceBasedCalculation());
	
	// Generated Method Threes.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Threes with the value of 3.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Threes<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Threes), 3, pointsCalculator);
	
	// Generated Override for Method Threes.

	/// <summary>
	/// <inheritdoc cref="Threes{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Threes{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Threes<TDice>(ILogger logger)
		where TDice : IDice
		=> Threes<TDice>(logger, new FaceBasedCalculation());
	
	// Generated Method Fours.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fours with the value of 4.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fours<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Fours), 4, pointsCalculator);
	
	// Generated Override for Method Fours.

	/// <summary>
	/// <inheritdoc cref="Fours{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Fours{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fours<TDice>(ILogger logger)
		where TDice : IDice
		=> Fours<TDice>(logger, new FaceBasedCalculation());
	
	// Generated Method Fives.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fives with the value of 5.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fives<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Fives), 5, pointsCalculator);
	
	// Generated Override for Method Fives.

	/// <summary>
	/// <inheritdoc cref="Fives{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Fives{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fives<TDice>(ILogger logger)
		where TDice : IDice
		=> Fives<TDice>(logger, new FaceBasedCalculation());
	
	// Generated Method Sixes.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Sixes with the value of 6.
	/// </summary>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Sixes<TDice>(ILogger logger, IPointsCalculator pointsCalculator)
		where TDice : IDice
		=> new(logger, nameof(Sixes), 6, pointsCalculator);
	
	// Generated Override for Method Sixes.

	/// <summary>
	/// <inheritdoc cref="Sixes{TDice}(ILogger, IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Sixes{TDice}(ILogger, IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <param name="logger"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(ILogger, string, int, IPointsCalculator)" path="/param[@name='logger']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Sixes<TDice>(ILogger logger)
		where TDice : IDice
		=> Sixes<TDice>(logger, new FaceBasedCalculation());
	}