namespace NetEvolve.Extensions.NUnit;

using System;
using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>AcceptanceTest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class AcceptanceTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptanceTestAttribute"/> class.
    /// </summary>
    public AcceptanceTestAttribute()
        : base(Internals.AcceptanceTest) { }
}
