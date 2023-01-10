namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using Xunit.Sdk;
using NetEvolve.Extensions.XUnit;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides property <see cref="Category"/>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CategoryTraitDiscoverer, Namespaces.Assembly)]
[SuppressMessage(
    "Naming",
    "CA1710:Identifiers should have correct suffix",
    Justification = "Conflicting naming convention"
)]
public abstract class CategoryTraitAttributeBase : Attribute, ITraitAttribute
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryTraitAttributeBase"/> class.
    /// </summary>
    /// <param name="category"></param>
    protected CategoryTraitAttributeBase(string category) => Category = category;
}
