namespace NetEvolve.Extensions.TUnit;

using System;
using NetEvolve.Extensions.TUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method with TestCategory PostDeployment.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class PostDeploymentAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute()
        : base(Internals.PostDeployment) { }
}
