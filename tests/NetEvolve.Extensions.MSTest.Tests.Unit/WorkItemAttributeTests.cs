namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="WorkItemAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class WorkItemAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> without additional information.
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
    [WorkItem]
    [WorkItem("")]
    public async Task WorkItem_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
    [WorkItem(123456)]
    public async Task WorkItem_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="WorkItemAttribute"/> with numeric id.
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
    [WorkItem("123456")]
    public async Task WorkItem_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
