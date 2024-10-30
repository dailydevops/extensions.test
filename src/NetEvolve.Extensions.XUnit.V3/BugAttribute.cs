namespace NetEvolve.Extensions.XUnit.V3;

using System;
using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>Bug</b>, with optional Id.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class BugAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class.
    /// </summary>
    public BugAttribute()
        : base(Internals.Bug, null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class.
    /// </summary>
    /// <param name="id">Bug Id</param>
    public BugAttribute(string? id)
        : base(Internals.Bug, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BugAttribute"/> class.
    /// </summary>
    /// <param name="id">Bug Id</param>
    public BugAttribute(long id)
        : base(Internals.Bug, id) { }
}
