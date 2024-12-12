namespace NetEvolve.Extensions.TUnit.Internal;

using System.Diagnostics.CodeAnalysis;
using global::TUnit.Core.Interfaces;

/// <summary>
/// Abstract class implementation of <see cref="ITestDiscoveryEventReceiver"/>.
/// Provides property <see cref="Category"/>.
/// </summary>
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "As designed.")]
public abstract class CategoryTraitBaseAttribute : Attribute, ITestDiscoveryEventReceiver
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

    /// <inheritdoc/>
    public void OnTestDiscovery(DiscoveredTestContext discoveredTestContext)
    {
        if (discoveredTestContext is null)
        {
            return;
        }

        discoveredTestContext.AddCategory(Category);
    }
}
