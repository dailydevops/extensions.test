namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

/// <summary>
/// Unit tests for <see cref="AcceptanceTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[UsesVerify]
public class AcceptanceTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [AcceptanceTest]
    [InlineData(nameof(AcceptanceTest_without_parameters))]
    [InlineData(nameof(AcceptanceTest_without_or_invalid_parameters))]
    public async Task AcceptanceTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [AcceptanceTest]
    protected void AcceptanceTest_without_parameters() => throw new NotSupportedException();
}
