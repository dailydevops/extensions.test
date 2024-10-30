namespace NetEvolve.Extensions.XUnit.V3;

using NetEvolve.Extensions.XUnit.V3.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>UserStory</b>, with optional Id
/// </summary>
public sealed class UserStoryAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class.
    /// </summary>
    public UserStoryAttribute()
        : base(Internals.UserStory, null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class.
    /// </summary>
    /// <param name="id">UserStory Id</param>
    public UserStoryAttribute(string? id)
        : base(Internals.UserStory, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class.
    /// </summary>
    /// <param name="id">UserStory Id</param>
    public UserStoryAttribute(long id)
        : base(Internals.UserStory, id) { }
}
