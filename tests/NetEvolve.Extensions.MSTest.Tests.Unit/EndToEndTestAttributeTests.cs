namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [EndToEndTest]
    [DataRow(nameof(EndToEndTest_without_parameters))]
    [DataRow(nameof(EndToEndTest_without_or_invalid_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [EndToEndTest]
    public void EndToEndTest_without_parameters() { }
}
