using FluentAssertions.Execution;

namespace Yatzy.Tests.Core.FluentAssertionExt;
public sealed class PointsAssertions
{
    readonly Points instance;
    AndConstraint<PointsAssertions> AndConstraint
        => new(this);
    public PointsAssertions(Points instance)
    {
        this.instance = instance;
    }
    /// <summary>
    /// Asserts if the given <see cref="Points"/> is empty.
    /// </summary>
    /// <param name="because">The reason it should be empty.</param>
    /// <param name="becauseArgs">The arguments to the reason.</param>
    /// <returns>new <see cref="AndConstraint{T}"/></returns>
    public AndConstraint<PointsAssertions> BeEmpty(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(!instance.HasPoints)
            .FailWith($"The instance of points was not empty. Contained {instance}.");
        return AndConstraint;
    }
    /// <summary>
    /// Checks if the current instance is equal to <paramref name="expected"/>.
    /// </summary>
    /// <param name="expected">The value to check against.</param>
    /// <param name="because">The reason it should be equal.</param>
    /// <param name="becauseArgs"><inheritdoc cref="BeEmpty(string, object[])" path="/param[@name='becauseArgs']"/></param>
    /// <returns><inheritdoc cref="BeEmpty(string, object[])" path="/returns"/></returns>
    public AndConstraint<PointsAssertions> Be(Points expected, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(instance == expected)
            .FailWith($"The two instances were unequal. The amount in the actual was {instance}, the amount in the expected was {expected}");
        return AndConstraint;
    }
}
