namespace NetEvolve.Extensions.XUnit;

using System;
using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>TestGroup</b>, with explicit id
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class TestGroupAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestGroupAttribute"/> class.
    /// </summary>
    /// <param id="id">TestGroup Name</param>
    public TestGroupAttribute(string id)
        : base(Internals.TestGroup, id) { }
}
