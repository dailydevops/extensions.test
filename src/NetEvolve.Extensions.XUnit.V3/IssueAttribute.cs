namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>Issue</b>, with optional Id
/// </summary>
public sealed class IssueAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    public IssueAttribute()
        : base(Internals.Issue, null) { }

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
        : base(Internals.Issue, id) { }
}
