﻿namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="IssueAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class IssueAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [Issue]
    [Issue("")]
    public async Task Issue_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [Issue(123456)]
    public async Task Issue_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with id.
    /// </summary>
    [Fact]
    [Issue("123456")]
    public async Task Issue_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
