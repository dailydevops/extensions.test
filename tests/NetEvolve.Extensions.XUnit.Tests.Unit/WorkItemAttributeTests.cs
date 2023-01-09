namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="WorkItemAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class WorkItemAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> without additional information.
    /// </summary>
    [Fact]
    [WorkItem]
    [WorkItem("")]
    public async Task WorkItem_without_Id()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [WorkItem(123456)]
    public async Task WorkItem_with_LongId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Fact]
    [WorkItem("123456")]
    public async Task WorkItem_with_StringId()
    {
        var traits = GetTraits();

        _ = await Verify(traits);
    }
}
