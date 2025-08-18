﻿namespace NetEvolve.Extensions.TUnit.Internal;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
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

    /// <inheritdoc cref="IEventReceiver.Order" />
    public int Order => 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryTraitBaseAttribute"/> class.
    /// </summary>
    /// <param name="category"></param>
    protected CategoryTraitBaseAttribute(string category) => Category = category;

    /// <inheritdoc/>
    public ValueTask OnTestDiscovered(DiscoveredTestContext context)
    {
        if (context is null)
        {
            return ValueTask.CompletedTask;
        }

        context.AddCategory(Category);

        return ValueTask.CompletedTask;
    }
}
