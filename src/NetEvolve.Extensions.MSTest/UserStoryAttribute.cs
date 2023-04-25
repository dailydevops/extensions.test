namespace NetEvolve.Extensions.MSTest;

using NetEvolve.Extensions.MSTest.Internal;
using System;

/// <summary>
/// Attribute used to decorate a test class or method as UserStory, with optional Id
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class UserStoryAttribute : TestCategoryWithIdBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserStoryAttribute"/> class.
    /// </summary>
    public UserStoryAttribute()
        : base(Internals.UserStory) { }

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
        : base(Internals.UserStory, $"{id}") { }
}
