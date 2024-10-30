namespace NetEvolve.Extensions.XUnit.V3.Internal;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit.V3;
using Xunit.Internal;
using Xunit.v3;

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
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "As designed.")]
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

    /// <inheritdoc />
    public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (!string.IsNullOrWhiteSpace(Category))
        {
            result.Add(Internals.TestCategory, Category);

            if (!string.IsNullOrWhiteSpace(Id))
            {
                result.Add(Category, Id);
            }
        }

        return result.CastOrToReadOnlyCollection();
    }
}
