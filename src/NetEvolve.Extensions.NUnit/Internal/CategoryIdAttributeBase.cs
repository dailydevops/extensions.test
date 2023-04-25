namespace NetEvolve.Extensions.NUnit.Internal;

using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;

/// <summary>
/// Abstract class implementation.
/// Extends <see cref="CategoryAttribute"/> with an additional property <see cref="Id"/>.
/// </summary>
public abstract class CategoryIdAttributeBase : CategoryAttribute, IApplyToTest
{
    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdAttributeBase"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    protected CategoryIdAttributeBase(string category)
        : base(category) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdAttributeBase"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryIdAttributeBase(string category, string? id)
        : base(category) => Id = id;

    /// <inheritdoc/>
    void IApplyToTest.ApplyToTest(Test test)
    {
        if (test is null)
        {
            return;
        }

        base.ApplyToTest(test);

        if (!string.IsNullOrEmpty(Id))
        {
            test.Properties.Add(Name, Id!);
        }
    }
}
