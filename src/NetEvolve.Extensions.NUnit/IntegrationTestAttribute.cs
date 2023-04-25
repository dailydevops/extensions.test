namespace NetEvolve.Extensions.NUnit;

using global::NUnit.Framework;
using System;

/// <summary>
/// Attribute used to decorate a test class or method as IntegrationTest.
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
