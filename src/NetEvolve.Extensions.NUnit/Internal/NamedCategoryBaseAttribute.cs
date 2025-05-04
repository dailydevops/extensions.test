namespace NetEvolve.Extensions.NUnit.Internal;

using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;

/// <summary>
/// Abstract class implementation.
/// </summary>
public abstract class NamedCategoryBaseAttribute : NUnitAttribute, IApplyToTest
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets the Id
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected NamedCategoryBaseAttribute(string category, string id)
    {
        Category = category;
        Id = id;
    }

    /// <inheritdoc/>
    public void ApplyToTest(Test test)
    {
        if (test is null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(Id))
        {
            test.Properties.Add(Category, Id!);
        }
    }
}
