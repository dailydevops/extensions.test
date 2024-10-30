namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>WorkItem</b>, with optional Id
/// </summary>
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
