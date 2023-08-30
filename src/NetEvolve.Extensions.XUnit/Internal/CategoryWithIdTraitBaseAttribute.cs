namespace NetEvolve.Extensions.XUnit.Internal;

using System;
using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

/// <summary>
/// <para>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides basic functionality for category / id based testing.
/// </para>
/// <para>
/// Like:
/// <list type="bullet">
/// <item><see cref="BugAttribute"/></item>
/// <item><see cref="EpicAttribute"/></item>
/// <item><see cref="FeatureAttribute"/></item>
/// <item><see cref="IssueAttribute"/></item>
/// <item><see cref="UserStoryAttribute"/></item>
/// <item><see cref="WorkItemAttribute"/></item>
/// </list>
/// </para>
/// </summary>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
[TraitDiscoverer(Namespaces.CategoryTraitDiscoverer, Namespaces.Assembly)]
[SuppressMessage(
    "Style",
    "IDE1006:Naming Styles",
    Justification = "As designed."
)]
public abstract class CategoryWithIdTraitBaseAttribute : Attribute, ITraitAttribute
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
    /// Initializes a new instance of the <see cref="CategoryWithIdTraitBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryWithIdTraitBaseAttribute(string category, string? id)
    {
        Category = category;
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryWithIdTraitBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryWithIdTraitBaseAttribute(string category, long id)
    {
        Category = category;
        Id = $"{id}";
    }
}
