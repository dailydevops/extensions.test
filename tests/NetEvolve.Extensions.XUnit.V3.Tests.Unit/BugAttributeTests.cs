﻿namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="BugAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class BugAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [Bug]
    [Bug("")]
    public async Task Bug_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [Bug(123456)]
    public async Task Bug_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [Fact]
    [Bug("123456")]
    public async Task Bug_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
