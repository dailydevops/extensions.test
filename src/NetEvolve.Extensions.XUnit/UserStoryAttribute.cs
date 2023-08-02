namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as UserStory, with optional Id
/// </summary>
public sealed class UserStoryAttribute : CategoryWithIdTraitAttributeBase
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
