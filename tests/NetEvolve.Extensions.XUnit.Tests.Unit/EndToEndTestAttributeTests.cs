namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [EndToEndTest]
    [InlineData(nameof(EndToEndTest_without_parameters))]
    [InlineData(nameof(EndToEndTest_without_or_invalid_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [EndToEndTest]
    protected void EndToEndTest_without_parameters() => throw new NotSupportedException();
}
