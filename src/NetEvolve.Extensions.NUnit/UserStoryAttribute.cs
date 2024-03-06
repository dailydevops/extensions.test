namespace NetEvolve.Extensions.NUnit;

using System;
using NetEvolve.Extensions.NUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as <b>UserStory</b>, with optional Id.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class UserStoryAttribute : CategoryIdBaseAttribute
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
