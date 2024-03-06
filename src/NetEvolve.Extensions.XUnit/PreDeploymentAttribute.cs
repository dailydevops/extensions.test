namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method with TestCategory PreDeployment.
/// </summary>
public sealed class PreDeploymentAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreDeploymentAttribute"/> class.
    /// </summary>
    public PreDeploymentAttribute()
        : base(Internals.PreDeployment) { }
}
