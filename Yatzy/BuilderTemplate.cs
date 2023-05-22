using System.Runtime.CompilerServices;

using Serilog;

using Yatzy.Errors;
using Yatzy.Logging;

namespace Yatzy;
/// <summary>
/// Represents a template for a builder.
/// </summary>
/// <typeparam name="TBuilding"><inheritdoc cref="IBuilder{TBuilding}" path="/typeparam"/></typeparam>
public abstract class BuilderTemplate<TBuilding> : IBuilder<TBuilding>
{
    readonly ILogger logger;
    /// <summary>
    /// Creates a new <see cref="BuilderTemplate{TBuilding}"/>.
    /// </summary>
    /// <param name="logger">The logger used throughout this application. Does not call <see cref="TypeContext.ForType{T}(ILogger)"/>.</param>
    protected BuilderTemplate(ILogger logger)
    {
        this.logger = logger;
    }
    /// <inheritdoc/>
    public TBuilding Build()
    {
        IEnumerable<Member> requiredMembers = RequiredMemberObjects();
        if (AnyNull(requiredMembers))
        {
            IEnumerable<string> nullParams = IdentifyNullValues(requiredMembers);
            logger.Error("The build has failed. The following parameters has not been overwritten: {NullParams}", nullParams);
            throw new BuildingContainedNullParameters
            {
                Parameters = nullParams
            };
        }
        return Create();
    }
    /// <summary>
    /// The members required to not be null.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{Member}"/> where each <see cref="Member"/> represents a required member in the builder.</returns>
    protected abstract IEnumerable<Member> RequiredMemberObjects();
    /// <summary>
    /// Creates the final product after all checks are complete.
    /// </summary>
    /// <returns>A new instance of <typeparamref name="TBuilding"/>.</returns>
    protected abstract TBuilding Create();
    static bool AnyNull(IEnumerable<Member> requiredMembers)
        => requiredMembers.Any(member => member.IsNull);
    static IEnumerable<string> IdentifyNullValues(IEnumerable<Member> requiredMembers)
    {
        foreach (Member member in requiredMembers)
        {
            if (member.IsNotNull)
                continue;
            yield return member.Name;
        }
    }
    /// <summary>
    /// Represents a member of the class.
    /// </summary>
    protected readonly struct Member
    {
        /// <summary>
        /// Whether the value is null.
        /// </summary>
        public bool IsNull { get; }
        /// <summary>
        /// Whether the value is not null.
        /// </summary>
        public bool IsNotNull
            => !IsNull;
        /// <summary>
        /// The name of the member.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Constructs a new instance of <see cref="Member"/>.
        /// </summary>
        /// <param name="value">The member passed in.</param>
        /// <param name="name">The name of the member. (Is captured)</param>
        public Member(in object? value, [CallerArgumentExpression("value")] string name = "")
        {
            Name = name;
            IsNull = value is null;
        }
    }
}
