namespace NetEvolve.Extensions.TUnit.Internal;

using System.Threading.Tasks;
using global::TUnit.Core;
using global::TUnit.Core.Interfaces;

/// <summary>
/// <para>
/// Abstract class implementation of <see cref="ITestDiscoveryEventReceiver"/>.
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
public abstract class CategoryWithIdTraitBaseAttribute : Attribute, ITestDiscoveryEventReceiver
{
    /// <summary>
    /// Gets the category value of the trait.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <inheritdoc cref="IEventReceiver.Order" />
    public int Order => 0;

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

    /// <inheritdoc/>
    public ValueTask OnTestDiscovered(DiscoveredTestContext context)
    {
        if (context is null)
        {
            return new ValueTask();
        }

        context.AddCategory(Category);
        if (!string.IsNullOrWhiteSpace(Id))
        {
            context.AddProperty(Category, Id!);
        }

        return new ValueTask();
    }
}
