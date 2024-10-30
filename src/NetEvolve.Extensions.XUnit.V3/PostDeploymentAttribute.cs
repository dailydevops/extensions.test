namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method with TestCategory PostDeployment.
/// </summary>
public sealed class PostDeploymentAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute()
        : base(Internals.PostDeployment) { }
}
