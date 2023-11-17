namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="PostDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class PostDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PostDeploymentAttribute"/>.
    /// </summary>
    [TestMethod]
    [PostDeployment]
    public async Task PostDeployment_Expected()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
