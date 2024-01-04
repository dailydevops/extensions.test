namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::NUnit.Framework;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class AcceptanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [AcceptanceTest]
    [TestCase(nameof(AcceptanceTest_without_parameters))]
    [TestCase(nameof(AcceptanceTest_without_or_invalid_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [AcceptanceTest]
    private void AcceptanceTest_without_parameters() => throw new NotSupportedException();
}
