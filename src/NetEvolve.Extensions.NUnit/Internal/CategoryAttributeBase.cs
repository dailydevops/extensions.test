namespace NetEvolve.Extensions.NUnit.Internal;

using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;
using System;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage(
    "Naming",
    "CA1710:Identifiers should have correct suffix",
    Justification = "Conflicting naming convention"
)]
public abstract class CategoryAttributeBase : Attribute, IApplyToTest
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdAttributeBase"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    protected CategoryAttributeBase(string category) => Category = category;

    /// <inheritdoc/>
    public virtual void ApplyToTest(Test test)
    {
        test.Properties.Add(PropertyNames.Category, Category);
        test.Properties.Add(Internals.TestCategory, Category);
    }
}
