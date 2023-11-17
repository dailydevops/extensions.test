namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="IssueAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class IssueAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> without additional information.
    /// </summary>
    [TestMethod]
    [Issue]
    [Issue("")]
    public async Task Issue_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with numeric id.
    /// </summary>
    [TestMethod]
    [Issue(123456)]
    public async Task Issue_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="IssueAttribute"/> with id.
    /// </summary>
    [TestMethod]
    [Issue("123456")]
    public async Task Issue_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
