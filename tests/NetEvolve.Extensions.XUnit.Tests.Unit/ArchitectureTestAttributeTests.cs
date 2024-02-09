namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="ArchitectureTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class ArchitectureTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [ArchitectureTest]
    [InlineData(nameof(ArchitectureTest_without_parameters))]
    [InlineData(nameof(ArchitectureTest_without_or_invalid_parameters))]
    public async Task ArchitectureTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [ArchitectureTest]
    protected void ArchitectureTest_without_parameters() => throw new NotSupportedException();
}
