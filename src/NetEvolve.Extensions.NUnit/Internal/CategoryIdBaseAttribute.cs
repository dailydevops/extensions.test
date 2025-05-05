namespace NetEvolve.Extensions.NUnit.Internal;

using System.Xml.Linq;
using global::NUnit.Framework;
using global::NUnit.Framework.Interfaces;
using global::NUnit.Framework.Internal;

/// <summary>
/// Abstract class implementation.
/// Extends <see cref="CategoryAttribute"/> with an additional property <see cref="Id"/>.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "As designed.")]
public abstract class CategoryIdBaseAttribute : CategoryAttribute, IApplyToTest
{
    /// <summary>
    /// Gets the Id
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    protected CategoryIdBaseAttribute(string category)
        : base(category) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryIdBaseAttribute"/> class.
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="id">Id</param>
    protected CategoryIdBaseAttribute(string category, string? id)
        : base(category) => Id = id;

    /// <inheritdoc/>
    void IApplyToTest.ApplyToTest(Test test)
    {
        if (test is null)
        {
            return;
        }

        ApplyToTest(test);

        if (!string.IsNullOrEmpty(Id))
        {
            test.Properties.Add(Name, Id!);
        }
    }
}
