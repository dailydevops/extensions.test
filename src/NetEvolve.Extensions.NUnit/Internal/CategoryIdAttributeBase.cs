namespace NetEvolve.Extensions.NUnit.Internal;

using global::NUnit.Framework.Internal;

public abstract class CategoryIdAttributeBase : CategoryAttributeBase
{
    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdAttributeBase"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    protected CategoryIdAttributeBase(string category) : base(category) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdAttributeBase"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryIdAttributeBase(string category, string? id) : base(category) => Id = id;

    /// <inheritdoc/>
    public override void ApplyToTest(Test test)
    {
        base.ApplyToTest(test);

        if (!string.IsNullOrEmpty(Id))
        {
            test.Properties.Add(Category, Id);
        }
    }
}
