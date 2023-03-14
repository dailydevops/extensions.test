namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as PreDeployment.
/// </summary>
public sealed class PreDeploymentAttribute : CategoryAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreDeploymentAttribute"/> class.
    /// </summary>
    public PreDeploymentAttribute()
        : base(Internals.PreDeployment) { }
}
