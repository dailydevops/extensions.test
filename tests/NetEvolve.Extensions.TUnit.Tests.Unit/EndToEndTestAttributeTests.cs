namespace NetEvolve.Extensions.TUnit.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="EndToEndTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class EndToEndTestAttributeTests : AttributeTestsBase
{
    [Test]
    [EndToEndTest]
    [Arguments(nameof(EndToEndTest_without_parameters))]
    [Arguments(nameof(EndToEndTest_without_or_invalid_parameters))]
    public async Task EndToEndTest_without_or_invalid_parameters(string methodName)
    {
        var traits = GetTraits(methodName);

        _ = await Verify(traits).UseParameters(methodName);
    }

    [EndToEndTest]
    protected void EndToEndTest_without_parameters() => throw new NotSupportedException();
}
