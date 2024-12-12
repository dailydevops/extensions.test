namespace NetEvolve.Extensions.TUnit;

using System;
using NetEvolve.Extensions.TUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>WorkItem</b>, with optional Id
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true
)]
public sealed class WorkItemAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class.
    /// </summary>
    public WorkItemAttribute()
        : base(Internals.WorkItem, null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class.
    /// </summary>
    /// <param name="id">WorkItem Id</param>
    public WorkItemAttribute(string? id)
        : base(Internals.WorkItem, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class.
    /// </summary>
    /// <param name="id">WorkItem Id</param>
    public WorkItemAttribute(long id)
        : base(Internals.WorkItem, id) { }
}
