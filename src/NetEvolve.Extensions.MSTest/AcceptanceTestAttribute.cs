namespace NetEvolve.Extensions.MSTest;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

/// <summary>
/// Attribute used to decorate a test class or method as AcceptanceTest.
/// </summary>
public sealed class AcceptanceTestAttribute : TestCategoryBaseAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptanceTestAttribute"/> class.
    /// </summary>
    public AcceptanceTestAttribute() { }

    /// <inheritdoc/>
    public override IList<string> TestCategories { get; } =
        new List<string> { Internals.AcceptanceTest };
}
