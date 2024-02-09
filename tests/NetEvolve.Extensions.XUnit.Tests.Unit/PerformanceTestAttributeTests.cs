namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="PerformanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class PerformanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [PerformanceTest]
    [InlineData(nameof(PerformanceTest_without_parameters))]
    [InlineData(nameof(PerformanceTest_without_or_invalid_parameters))]
    public async Task PerformanceTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [PerformanceTest]
    protected void PerformanceTest_without_parameters() => throw new NotSupportedException();
}
