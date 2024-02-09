namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="ArchitectureTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class ArchitectureTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [ArchitectureTest]
    [TestCase(nameof(ArchitectureTest_without_parameters))]
    [TestCase(nameof(ArchitectureTest_without_or_invalid_parameters))]
    public async Task ArchitectureTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [ArchitectureTest]
    private void ArchitectureTest_without_parameters() => throw new NotSupportedException();
}
