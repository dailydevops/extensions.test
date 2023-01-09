namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

/// <summary>
/// Unit tests for <see cref="PerformanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class PerformanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [PerformanceTest]
    [InlineData(nameof(PerformanceTest_without_parameters))]
    public async Task PerformanceTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [PerformanceTest]
    [SuppressMessage("Usage", "xUnit1013", Justification = "Reviewed.")]
    public void PerformanceTest_without_parameters() { }
}
