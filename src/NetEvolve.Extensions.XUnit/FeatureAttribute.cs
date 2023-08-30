namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method as Feature, with optional Id
/// </summary>
public sealed class FeatureAttribute : CategoryWithIdTraitBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureAttribute"/> class.
    /// </summary>
    public FeatureAttribute()
        : base(Internals.Feature, null) { }

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
        : base(Internals.Feature, id) { }
}
