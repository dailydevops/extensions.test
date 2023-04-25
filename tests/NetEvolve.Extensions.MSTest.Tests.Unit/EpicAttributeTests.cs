namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="EpicAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class EpicAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> without additional information.
    /// </summary>
    [TestMethod]
    [Epic]
    [Epic("")]
    public async Task Epic_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="EpicAttribute"/> with numeric id.
    /// </summary>
    [TestMethod]
    [Epic(123456)]
    public async Task Epic_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [TestMethod]
    [Epic("123456")]
    public async Task Epic_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
