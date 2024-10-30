namespace NetEvolve.Extensions.NUnit;

using System;
using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>EndToEndTest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class EndToEndTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndToEndTestAttribute"/> class.
    /// </summary>
    public EndToEndTestAttribute()
        : base(Internals.EndToEndTest) { }
}
