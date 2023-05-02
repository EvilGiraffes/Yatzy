// This is a generated file!
// Do not manually modify as your changes will be overwritten.

using Serilog;

using Yatzy.Dices;
using Yatzy.Rules.PointsCalculators;

namespace Yatzy.Rules;
/// <summary>
/// A factory to create predetermined <see cref="SameValueRule{TDice}"/>.
/// </summary>
public static class SameValueRuleFactory<TDice>
	where TDice : IDice
{
	
	// Generated Method Aces.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Aces with the value of 1.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Aces(IPointsCalculator pointsCalculator)
		=> new(nameof(Aces), 1, pointsCalculator);
	
	// Generated Override for Aces.

	/// <summary>
	/// <inheritdoc cref="Aces(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Aces(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Aces()
		=> Aces(new FaceBasedCalculation());
	
	// Generated Method Twos.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Twos with the value of 2.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Twos(IPointsCalculator pointsCalculator)
		=> new(nameof(Twos), 2, pointsCalculator);
	
	// Generated Override for Twos.

	/// <summary>
	/// <inheritdoc cref="Twos(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Twos(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Twos()
		=> Twos(new FaceBasedCalculation());
	
	// Generated Method Threes.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Threes with the value of 3.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Threes(IPointsCalculator pointsCalculator)
		=> new(nameof(Threes), 3, pointsCalculator);
	
	// Generated Override for Threes.

	/// <summary>
	/// <inheritdoc cref="Threes(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Threes(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Threes()
		=> Threes(new FaceBasedCalculation());
	
	// Generated Method Fours.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fours with the value of 4.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fours(IPointsCalculator pointsCalculator)
		=> new(nameof(Fours), 4, pointsCalculator);
	
	// Generated Override for Fours.

	/// <summary>
	/// <inheritdoc cref="Fours(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Fours(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fours()
		=> Fours(new FaceBasedCalculation());
	
	// Generated Method Fives.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Fives with the value of 5.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fives(IPointsCalculator pointsCalculator)
		=> new(nameof(Fives), 5, pointsCalculator);
	
	// Generated Override for Fives.

	/// <summary>
	/// <inheritdoc cref="Fives(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Fives(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Fives()
		=> Fives(new FaceBasedCalculation());
	
	// Generated Method Sixes.

	/// <summary>
	/// Represents a <see cref="SameValueRule{TDice}"/> of Sixes with the value of 6.
	/// </summary>
	/// <param name="pointsCalculator"><inheritdoc cref="SameValueRule{TDice}.SameValueRule(string, int, IPointsCalculator)" path="/param[@name='pointsCalculator']"/></param>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Sixes(IPointsCalculator pointsCalculator)
		=> new(nameof(Sixes), 6, pointsCalculator);
	
	// Generated Override for Sixes.

	/// <summary>
	/// <inheritdoc cref="Sixes(IPointsCalculator)" path="/summary"/>
	/// </summary>
	/// <remarks>
	/// <para>Uses the default implementation for <see cref="IPointsCalculator"/> in <see cref="Sixes(IPointsCalculator)"/>.</para>
	/// <para>The default implementation is <see cref="FaceBasedCalculation"/>.</para>
	/// </remarks>
	/// <returns>A new <see cref="SameValueRule{TDice}"/> which contains the predetermined values.</returns>
	public static SameValueRule<TDice> Sixes()
		=> Sixes(new FaceBasedCalculation());
	}