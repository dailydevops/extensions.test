namespace NetEvolve.Extensions.MSTest;

using System;
using NetEvolve.Extensions.MSTest.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as Feature, with optional Id
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class FeatureAttribute : TestCategoryWithIdBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
    /// </summary>
    public FeatureAttribute()
        : base(Internals.Feature) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
    /// </summary>
    /// <param name="id">Feature Id</param>
    public FeatureAttribute(string? id)
        : base(Internals.Feature, id) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
    /// </summary>
    /// <param name="id">Feature Id</param>
    public FeatureAttribute(long id)
        : base(Internals.Feature, $"{id}") { }
}
