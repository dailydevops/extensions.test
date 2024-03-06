namespace NetEvolve.Extensions.NUnit;

using System;
using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>IntegrationTest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
public sealed class IntegrationTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationTestAttribute"/> class.
    /// </summary>
    public IntegrationTestAttribute()
        : base(Internals.IntegrationTest) { }
}
