namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using Xunit.Sdk;

/// <summary>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides property <see cref="Category"/>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CategoryTraitDiscoverer, Namespaces.Assembly)]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "As designed.")]
public abstract class CategoryTraitBaseAttribute : Attribute, ITraitAttribute
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryTraitBaseAttribute"/> class.
    /// </summary>
    /// <param name="category"></param>
    protected CategoryTraitBaseAttribute(string category) => Category = category;
}
