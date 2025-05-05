namespace NetEvolve.Extensions.TUnit;

using System;
using NetEvolve.Extensions.TUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>TestGroup</b>, with explicit id
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class TestGroupAttribute : NamedCategoryTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestGroupAttribute"/> class.
    /// </summary>
    /// <param id="id">TestGroup Name</param>
    public TestGroupAttribute(string id)
        : base(Internals.TestGroup, id) { }
}
