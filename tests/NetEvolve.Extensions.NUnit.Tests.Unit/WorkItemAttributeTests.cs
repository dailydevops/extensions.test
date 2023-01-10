namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="WorkItemAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class WorkItemAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> without additional information.
    /// </summary>
    [Test]
    [WorkItem]
    [WorkItem("")]
    public async Task WorkItem_without_Id()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Test]
    [WorkItem(123456)]
    public async Task WorkItem_with_LongId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Test]
    [WorkItem("123456")]
    public async Task WorkItem_with_StringId()
    {
        var properties = GetProperties();

        _ = await Verify(properties);
    }
}
