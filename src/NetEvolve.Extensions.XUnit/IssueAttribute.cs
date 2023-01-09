namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as Issue, with optional Id
/// </summary>
public sealed class IssueAttribute : CategoryWithIdTraitAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    public IssueAttribute() : base(Internals.Issue, null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    /// <param name="id">Issue Id</param>
    public IssueAttribute(string? id) : base(Internals.Issue, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueAttribute"/> class.
    /// </summary>
    /// <param name="id">Issue Id</param>
    public IssueAttribute(long id) : base(Internals.Issue, id) { }
}
