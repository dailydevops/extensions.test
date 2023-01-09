namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using Xunit.Sdk;
using NetEvolve.Extensions.XUnit;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CategoryTraitDiscoverer, Namespaces.Assembly)]
public abstract class CategoryTraitAttribute : Attribute, ITraitAttribute
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryTraitAttribute"/> class.
    /// </summary>
    /// <param name="category"></param>
    protected CategoryTraitAttribute(string category) => Category = category;
}
