namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="FunctionalTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class FunctionalTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [FunctionalTest]
    [DataRow(nameof(FunctionalTest_without_parameters))]
    [DataRow(nameof(FunctionalTest_without_or_invalid_parameters))]
    public async Task FunctionalTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [FunctionalTest]
    private void FunctionalTest_without_parameters() { }
}
