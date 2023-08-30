namespace NetEvolve.Extensions.NUnit;

using NetEvolve.Extensions.NUnit.Internal;
using System;

/// <summary>
/// Attribute used to decorate a test class or method as Issue, with optional Id
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class IssueAttribute : CategoryIdBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    public IssueAttribute()
        : base(Internals.Issue) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    /// <param name="id">Issue Id</param>
    public IssueAttribute(string? id)
        : base(Internals.Issue, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    /// <param name="id">Issue Id</param>
    public IssueAttribute(long id)
        : base(Internals.Issue, $"{id}") { }
}
