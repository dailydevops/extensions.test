namespace NetEvolve.Extensions.MSTest.Internal;

/// <inheritdoc cref="TestTraitBaseAttribute" />
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "As designed.")]
public abstract class TestCategoryWithIdBaseAttribute : TestTraitBaseAttribute
{
    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <inheritdoc cref="TestTraitBaseAttribute" />
    protected TestCategoryWithIdBaseAttribute(string categoryName, string? id = default)
        : base(categoryName) => Id = id;
}
