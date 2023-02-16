// This is a generated file!
// Do not manually modify as your changes will be overwritten.

using Serilog;

namespace Yatzy.Rules;
/// <summary>
/// A factory to create predetermined <see cref="SameValueRule"/>.
/// </summary>
public static class SameValueRuleFactory
{
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Aces with the value of 1.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Aces(ILogger logger)
		=> new(logger, nameof(Aces), 1, 1);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Twos with the value of 2.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Twos(ILogger logger)
		=> new(logger, nameof(Twos), 2, 2);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Threes with the value of 3.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Threes(ILogger logger)
		=> new(logger, nameof(Threes), 3, 3);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Fours with the value of 4.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Fours(ILogger logger)
		=> new(logger, nameof(Fours), 4, 4);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Fives with the value of 5.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Fives(ILogger logger)
		=> new(logger, nameof(Fives), 5, 5);
	
	// Generated Method.

	/// <summary>
	/// Represents a <see cref="SameValueRule"/> of Sixes with the value of 6.
	/// </summary>
	/// <param name="logger">The logger used throughout this application.</param>
	/// <returns>A new <see cref="SameValueRule"/> which contains the predetermined values.</returns>
	public static SameValueRule Sixes(ILogger logger)
		=> new(logger, nameof(Sixes), 6, 6);
	}