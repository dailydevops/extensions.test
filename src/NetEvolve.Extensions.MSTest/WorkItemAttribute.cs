﻿namespace NetEvolve.Extensions.MSTest;

using System;
using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>WorkItem</b>, with optional Id.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class WorkItemAttribute : TestCategoryWithIdBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkItemAttribute"/> class.
    /// </summary>
    public WorkItemAttribute()
        : base(Internals.WorkItem) { }

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
        : base(Internals.WorkItem, $"{id}") { }
}
