namespace NetEvolve.Extensions.TUnit.Internal;

using global::TUnit.Core.Interfaces;

/// <summary>
/// Abstract implementation.
/// </summary>
public abstract class NamedCategoryTraitBaseAttribute : Attribute, ITestDiscoveryEventReceiver
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
    /// Initializes a new instance of the <see cref="NamedCategoryTraitBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected NamedCategoryTraitBaseAttribute(string category, string id)
    {
        Category = category;
        Id = id;
    }

    /// <inheritdoc/>
    public void OnTestDiscovery(DiscoveredTestContext discoveredTestContext)
    {
        if (discoveredTestContext is null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(Id))
        {
            discoveredTestContext.AddProperty(Category, Id);
        }
    }
}
