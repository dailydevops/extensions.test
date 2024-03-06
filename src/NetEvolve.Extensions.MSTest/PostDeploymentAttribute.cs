namespace NetEvolve.Extensions.MSTest;

using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PostDeployment</b>.
/// </summary>
public sealed class PostDeploymentAttribute : TestTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute()
        : base(Internals.PostDeployment) { }
}
