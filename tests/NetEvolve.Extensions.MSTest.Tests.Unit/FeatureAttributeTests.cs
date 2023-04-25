namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="FeatureAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class FeatureAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> without additional information.
    /// </summary>
    [TestMethod]
    [Feature]
    [Feature("")]
    public async Task Feature_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="FeatureAttribute"/> with numeric id.
    /// </summary>
    [TestMethod]
    [Feature(123456)]
    public async Task Feature_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="BugAttribute"/> with id.
    /// </summary>
    [TestMethod]
    [Feature("123456")]
    public async Task Feature_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
