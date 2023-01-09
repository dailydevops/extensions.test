namespace NetEvolve.Extensions.XUnit.Internal;
using System;
using Xunit.Sdk;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CategoryTraitDiscoverer, Namespaces.Assembly)]
public abstract class CategoryWithIdTraitAttribute : Attribute, ITraitAttribute
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryWithIdTraitAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryWithIdTraitAttribute(string category, string? id)
    {
        Category = category;
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryWithIdTraitAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryWithIdTraitAttribute(string category, long id)
    {
        Category = category;
        Id = $"{id}";
    }
}
