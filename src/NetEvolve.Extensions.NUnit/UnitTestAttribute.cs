namespace NetEvolve.Extensions.NUnit;

using System;
using global::NUnit.Framework;

/// <summary>
/// Attribute used to decorate a test class or method as <b>UnitTest</b>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class UnitTestAttribute : CategoryAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitTestAttribute"/> class.
    /// </summary>
    public UnitTestAttribute()
        : base(Internals.UnitTest) { }
}
