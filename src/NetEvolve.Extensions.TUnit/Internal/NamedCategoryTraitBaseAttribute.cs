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

    /// <inheritdoc cref="IEventReceiver.Order" />
    public int Order => 0;

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
    public ValueTask OnTestDiscovered(DiscoveredTestContext context)
    {
        if (context is null)
        {
            return new ValueTask();
        }

        if (!string.IsNullOrWhiteSpace(Id))
        {
            context.AddProperty(Category, Id);
        }

        return new ValueTask();
    }
}
