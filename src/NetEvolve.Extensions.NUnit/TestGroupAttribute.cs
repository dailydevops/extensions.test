namespace NetEvolve.Extensions.NUnit;

using System;
using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>TestGroup</b>, with explicit id
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class TestGroupAttribute : NamedCategoryBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestGroupAttribute"/> class.
    /// </summary>
    /// <param name="id">TestGroup Name</param>
    public TestGroupAttribute(string id)
        : base(Internals.TestGroup, id) { }
}
