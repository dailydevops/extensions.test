namespace NetEvolve.Extensions.TUnit;

using System;
using NetEvolve.Extensions.TUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>IntegrationTest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class IntegrationTestAttribute : CategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationTestAttribute"/> class.
    /// </summary>
    public IntegrationTestAttribute()
        : base(Internals.IntegrationTest) { }
}
