﻿namespace NetEvolve.Extensions.MSTest.Internal;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

/// <inheritdoc/>
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Style",
    "IDE1006:Naming Styles",
    Justification = "As designed."
)]
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
)]
public abstract class TestTraitBaseAttribute : TestCategoryBaseAttribute
{
    /// <inheritdoc/>
    public override IList<string> TestCategories { get; }

    /// <inheritdoc/>
    protected TestTraitBaseAttribute(string categoryName)
        : base() => TestCategories = new List<string> { categoryName };
}