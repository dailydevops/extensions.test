namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

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
