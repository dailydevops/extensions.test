namespace NetEvolve.Extensions.XUnit.V3.Internal;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit.Internal;
using Xunit.v3;

/// <summary>
/// Abstract class implementation of <see cref="ITraitAttribute"/>.
/// Provides property <see cref="Category"/>.
/// </summary>
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

    /// <inheritdoc />
    public IReadOnlyCollection<KeyValuePair<string, string>> GetTraits()
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (!string.IsNullOrWhiteSpace(Category))
        {
            result.Add(Internals.TestCategory, Category);
        }

        return result.CastOrToReadOnlyCollection();
    }
}
