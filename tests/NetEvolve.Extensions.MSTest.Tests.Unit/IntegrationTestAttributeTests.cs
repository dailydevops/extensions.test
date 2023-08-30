namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="IntegrationTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class IntegrationTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [IntegrationTest]
    [DataRow(nameof(IntegrationTest_without_parameters))]
    [DataRow(nameof(IntegrationTest_without_or_invalid_parameters))]
    public async Task IntegrationTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [IntegrationTest]
    private void IntegrationTest_without_parameters() { }
}
