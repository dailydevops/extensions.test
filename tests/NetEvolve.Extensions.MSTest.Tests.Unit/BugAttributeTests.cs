namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="BugAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class BugAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> without additional information.
    /// </summary>
    [TestMethod]
    [Bug]
    [Bug("")]
    public async Task Bug_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with numeric id.
    /// </summary>
    [TestMethod]
    [Bug(123456)]
    public async Task Bug_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [TestMethod]
    [Bug("123456")]
    public async Task Bug_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
