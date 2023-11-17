namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="UserStoryAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class UserStoryAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> without additional information.
    /// </summary>
    [TestMethod]
    [UserStory]
    [UserStory("")]
    public async Task UserStory_without_Id()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> with numeric id.
    /// </summary>
    [TestMethod]
    [UserStory(123456)]
    public async Task UserStory_with_LongId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }

    /// <summary>
    /// Tests the case of methods with <see cref="UserStoryAttribute"/> with id.
    /// </summary>
    [TestMethod]
    [UserStory("123456")]
    public async Task UserStory_with_StringId()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
