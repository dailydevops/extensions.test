namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as PostDeployment.
/// </summary>
public sealed class PostDeploymentAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute() : base(Internals.PostDeployment) { }
}
