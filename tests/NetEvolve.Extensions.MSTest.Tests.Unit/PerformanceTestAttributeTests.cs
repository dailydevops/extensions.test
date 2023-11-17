namespace NetEvolve.Extensions.MSTest.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Unit tests for <see cref="PerformanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestClass]
public class PerformanceTestAttributeTests : AttributeTestsBase
{
    [TestMethod]
    [PerformanceTest]
    [DataRow(nameof(PerformanceTest_without_parameters))]
    [DataRow(nameof(PerformanceTest_without_or_invalid_parameters))]
    public async Task PerformanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await VerifyMSTest(properties).UseParameters(methodName);
    }

    [PerformanceTest]
    private void PerformanceTest_without_parameters() { }
}
