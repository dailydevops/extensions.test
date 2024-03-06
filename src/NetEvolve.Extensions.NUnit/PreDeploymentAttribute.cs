namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>PreDeployment</b>.
/// </summary>
public sealed class PreDeploymentAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreDeploymentAttribute"/> class.
    /// </summary>
    public PreDeploymentAttribute()
        : base(Internals.PreDeployment) { }
}
