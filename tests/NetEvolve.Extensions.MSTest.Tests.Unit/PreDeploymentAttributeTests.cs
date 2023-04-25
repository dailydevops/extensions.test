namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="PreDeploymentAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class PreDeploymentAttributeTests : AttributeTestsBase
{
    /// <summary>
    /// Tests the case of methods with <see cref="PreDeploymentAttribute"/>.
    /// </summary>
    [TestMethod]
    [PreDeployment]
    public async Task PreDeployment_Expected()
    {
        var properties = GetProperties();

        _ = await VerifyMSTest(properties);
    }
}
