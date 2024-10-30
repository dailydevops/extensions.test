namespace NetEvolve.Extensions.XUnit.V3.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="IntegrationTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class IntegrationTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [IntegrationTest]
    [InlineData(nameof(IntegrationTest_without_parameters))]
    [InlineData(nameof(IntegrationTest_without_or_invalid_parameters))]
    public async Task IntegrationTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [IntegrationTest]
    protected void IntegrationTest_without_parameters() => throw new NotSupportedException();
}
