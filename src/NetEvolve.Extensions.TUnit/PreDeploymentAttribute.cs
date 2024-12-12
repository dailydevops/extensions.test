namespace NetEvolve.Extensions.TUnit;

using System;
using NetEvolve.Extensions.TUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method with TestCategory PreDeployment.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class PreDeploymentAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreDeploymentAttribute"/> class.
    /// </summary>
    public PreDeploymentAttribute()
        : base(Internals.PreDeployment) { }
}
