namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="PerformanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PerformanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [PerformanceTest]
    [TestCase(nameof(PerformanceTest_without_parameters))]
    public async Task PerformanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [PerformanceTest]
    public void PerformanceTest_without_parameters() { }
}
