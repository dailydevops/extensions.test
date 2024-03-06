namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PostDeployment</b>.
/// </summary>
public sealed class PostDeploymentAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute()
        : base(Internals.PostDeployment) { }
}
